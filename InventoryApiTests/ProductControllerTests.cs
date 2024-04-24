// Code generated by DevUp technologies, 11/12/2023 17:23:46
using CommonInterfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using InventoryWApi.Controllers;
using InventoryApiTests.ObjectFactories;

namespace InventoryApiTests
{
	/*
	Please note that unit tests below are given to give you a file with very basic functions of testing the API controller
	Please do not take these unit tests as a final and fully functional, Please go through these tests and improve as required
	Please also add more tests as per your API controller actions
	*/
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void Create_ProductController_Test()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var controller = new ProductController(mockService.Object);
            var product = ProductObjectFactory.CreateSingle(1);

            // Act
            var result = controller.CreateProduct(product);

            // Assert
            mockService.Verify(s => s.Create(product), Times.Once());
            Assert.IsInstanceOfType(result, typeof(Task<ActionResult<bool>>));
        }

        [TestMethod]
        public void CreateGetId_ProductController_Test()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var controller = new ProductController(mockService.Object);
            var product = ProductObjectFactory.CreateSingle(1);

            // Act
            var result = controller.CreateGetIdProduct(product);

            // Assert
            mockService.Verify(s => s.CreateGetId(product), Times.Once());
            Assert.IsInstanceOfType(result, typeof(Task<ActionResult<long>>));
            Assert.AreNotEqual(0, result.Result);
        }

        [TestMethod]
        public void GetById_ProductController_Test()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var controller = new ProductController(mockService.Object);
            var product = ProductObjectFactory.CreateSingle(1);
            Task<ActionResult<ProductDTO>> expectedResult = null;
            mockService.Setup(s => s.GetById(It.IsAny<long>())).ReturnsAsync(ProductObjectFactory.CreateSingle(1));

            // Act
            var result = controller.GetProduct(1);

            // Assert
            mockService.Verify(s => s.GetById(1), Times.Once());

            Assert.IsInstanceOfType(result, typeof(Task<ActionResult<ProductDTO>>));
            Assert.AreEqual(product.Id, result.Result.Value.Id);
        }

        [TestMethod]
        public void GetByFilter_ProductController_Test()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var controller = new ProductController(mockService.Object);
            var products = ProductObjectFactory.CreateMany(3);
            Task<ActionResult<ProductDTO>> expectedResult = null;
            ProductFilterDTO filter = new ProductFilterDTO();
            mockService.Setup(s => s.GetByFilter(It.IsAny<ProductFilterDTO>())).ReturnsAsync(ProductObjectFactory.CreateMany(3));

            // Act
            var result = controller.GetByFilter(filter);

            // Assert
            mockService.Verify(s => s.GetByFilter(filter), Times.Once());

            Assert.IsInstanceOfType(result, typeof(Task<ActionResult<List<ProductDTO>>>));
            Assert.AreEqual(products.Count, result.Result.Value.Count);
		}

        [TestMethod]
        public void Update_ProductController_Test()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var controller = new ProductController(mockService.Object);
            var product = ProductObjectFactory.CreateSingle(1);

            // Act
            var result = controller.UpdateProduct(1, product);

            // Assert
            mockService.Verify(s => s.Update(product), Times.Once());
            Assert.IsInstanceOfType(result, typeof(Task<ActionResult<bool>>));
        }

        [TestMethod]
        public void Delete_ProductController_Test()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var controller = new ProductController(mockService.Object);
            var product = ProductObjectFactory.CreateSingle(1);

            // Act
            var result = controller.DeleteProduct(product.Id);

            // Assert
            mockService.Verify(s => s.DeleteById(product.Id), Times.Once());
            Assert.IsInstanceOfType(result, typeof(Task<ActionResult<bool>>));
        }
    }
}



