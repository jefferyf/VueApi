﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VueApi.Controllers;
using VueApi.Models;
using VueApi.Repositories.Interfaces;
using VueApi.Services;

namespace VueApi.UnitTests.Controllers
{
    [TestFixture]
    class BooksControllerTests
    {
        private BooksController _booksController;
        private Mock<IBookRepository> _bookRepository;


        [Test]
        public void BookExists_BookIsFound_ReturnsTrue()
        {
            var booksRepo = new Mock<IBookRepository>();
            booksRepo.Setup(br => br.FindBookAsync(1)).Returns(Task.FromResult( new Book { Name = "book", Year = 2019 }));
            var booksController = new BooksController(booksRepo.Object);

            var result = booksController.GetBook(1);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);

        }
    }
}
