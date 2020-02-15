using NUnit.Framework;
using social_journal.DL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace social_journal.Tests
{
    public class DBTests : BaseTestProvider
    {
        const string testEntityIdentifier = "_TESTENTITY";

        [SetUp]
        public void Setup()
        {
            Instance.RunWithContext((ctx) =>
            {
                Task.Run(async () =>
                {
                    ctx.Logger.Info($"Test: {nameof(Setup)} started. Removing test entities.");
                    await ctx.RepositoryProvider.PostsRepository.Remove((post) => post.Title.Contains(testEntityIdentifier));
                    ctx.Logger.Info($"Test: {nameof(Setup)} ended.");
                }).GetAwaiter().GetResult();
            });
        }

        [Test]
        public void TestDB()
        {
           Instance.RunWithContext((ctx) =>
           {
               Task.Run(async () =>
               {
                   ctx.Logger.Info($"Test: {nameof(TestDB)} started.");
                   var testRepository = ctx.RepositoryProvider.PostsRepository;
                   var testEntity = new Post("TestPost" + testEntityIdentifier);

                   await testRepository.Add(testEntity);

                   Post returnedEntity = await testRepository.GetByID(testEntity.ID);
                   Assert.IsNotNull(returnedEntity, $"Test: {nameof(TestDB)}\n" +
                       $"Method: {nameof(testRepository.Add)} " +
                       $"Or {nameof(testRepository.GetByID)}\n" +
                       "Wrong value returned.");

                   await testRepository.Remove(testEntity);
                   Post removedEntity = await testRepository.GetByID(testEntity.ID);
                   Assert.IsNull(removedEntity, $"Test: {nameof(TestDB)}\n" +
                       $"Method: {nameof(testRepository.Remove)} " +
                       $"Or {nameof(testRepository.GetByID)}\n" +
                       "Wrong value returned.");

                   var testEntities = new List<Post>()
                   {
                       new Post("TestPost1" + testEntityIdentifier),
                       new Post("TestPost2" + testEntityIdentifier),
                       new Post("3PostTest" + testEntityIdentifier),
                   };
                   await testRepository.Add(testEntities);

                   IEnumerable<Post> entitiesWithConditions = await testRepository.GetWithConditions((post) => post.Title.StartsWith("TestPost"));
                   Assert.AreEqual(entitiesWithConditions.Count(), 2, $"Test: {nameof(TestDB)}\n" +
                       $"Method: {nameof(testRepository.Add)} multiple " +
                       $"Or {nameof(testRepository.GetWithConditions)}\n" +
                       "Wrong value returned.");

                   Post[] entitesPaged = (await testRepository.GetPaged((post) => post.Title.Contains(testEntityIdentifier), 1, 2))
                        .ToArray();
                   if (entitesPaged.Length != 2 || entitesPaged.Any((post) => !post.Title.Contains(testEntityIdentifier)))
                       Assert.Fail();
                   Assert.Less(entitesPaged[0].ID, entitesPaged[1].ID);

                   IEnumerable<Post> lastPage = await testRepository.GetPaged((post) => post.Title.Contains(testEntityIdentifier), 2, 2);
                   Assert.AreEqual(lastPage.Count(), 1);

                   await testRepository.Remove(testEntities);

                   IEnumerable<Post> testEntitiesRemoved = await testRepository.GetWithConditions((post) => post.Title.Contains(testEntityIdentifier));
                   Assert.AreEqual(testEntitiesRemoved.Count(), 0);

                   ctx.Logger.Info($"Test: {nameof(TestDB)} ended");
               }).GetAwaiter().GetResult();
           });
           Assert.Pass();
        }
    }
}