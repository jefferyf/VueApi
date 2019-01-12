using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using VueApi.Repositories.Interfaces;
using VueApi.Services;
using Microsoft.EntityFrameworkCore;
using VueApi.Models;

namespace VueApi.UnitTests.Repositories
{
    [TestFixture]
    class BookRepositoryTests
    {
        private Mock<IBookRepository> _bookRepository;
        private Mock<BooksDbContext> _context;

        [SetUp]
        public void SetUp()
        {
            _bookRepository = new Mock<IBookRepository>();
        }

        #region BookExist Tests

        [Test]
        public void BookExists_BookDoesNotExist_ReturnsFalse()
        {
            _bookRepository.Setup(br => br.BookExists(1)).Returns(false);

            var result = _bookRepository.Object.BookExists(1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void BookExists_BookDoesExist_ReturnsTrue()
        {
            _bookRepository.Setup(br => br.BookExists(2)).Returns(true);

            var result = _bookRepository.Object.BookExists(2);

            Assert.That(result, Is.True);
        }

        #endregion BookExist Tests
    }
}
