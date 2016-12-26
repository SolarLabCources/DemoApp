using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessLogic.Abstraction;
using BusinessLogic.Implementation;
using BusinessLogic.Objects;
using DataAccessLayer;
using DataAccessLayer.Objects;
using Moq;
using NUnit.Framework;

namespace Tests
{

    [TestFixture]
    public class PostManagerTests
    {
        IPostManager _manager;
        Mock<DemoContext> _contextMoq;

        public PostManagerTests()
        {
            _contextMoq = new Mock<DemoContext>();
            _manager = new PostManager(_contextMoq.Object);
            AutoMapperConfig.Initialize();
        }

        [Test]
        public void Test_PutPost()
        {
            //Arrange
            Mock<DbSet<Post>> dbSetMock = new Mock<DbSet<Post>>();
            _contextMoq.Setup(x => x.Posts).Returns(dbSetMock.Object);
            var dto = new AddPostDto {Title = "test"};

            //Act
            _manager.AddPost(dto);

            //Assert
            _contextMoq.Verify(x => x.SaveChanges(), Times.Once);
            dbSetMock.Verify(x => x.Add(It.IsAny<Post>()), Times.Once);
        }

    }

}
