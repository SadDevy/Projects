﻿using NUnit.Framework;
using PointProcessor;

namespace PointProcessorTests
{
    [TestFixture]
    public class FormatterTests
    {
        [Test]
        public void TestFormat_XZeroYZero_Success()
        {
            Point zeroPoint = new Point(0, 0);
            const string expectedFormatted = "X:    0,0    Y:    0,0   ";

            string actualFormated = Formatter.Format(zeroPoint);

            Assert.AreEqual(expectedFormatted, actualFormated);
        }

        [Test]
        public void TestFormat_XBigYBig_Success()
        {
            Point point = new Point(1234.5678m, 8765.4321m);
            const string expectedFormatted = "X: 1234,5678 Y: 8765,4321";

            string actualFormated = Formatter.Format(point);

            Assert.AreEqual(expectedFormatted, actualFormated);
        }

        [Test]
        public void TestFormat_XZeroYBig_Success()
        {
            Point point = new Point(0, 8765.4321m);
            const string expectedFormatted = "X:    0,0    Y: 8765,4321";

            string actualFormated = Formatter.Format(point);

            Assert.AreEqual(expectedFormatted, actualFormated);
        }

        [Test]
        public void TestFormat_XBigYZero_Success()
        {
            Point point = new Point(1234.5678m, 0);
            const string expectedFormatted = "X: 1234,5678 Y:    0,0   ";

            string actualFormated = Formatter.Format(point);

            Assert.AreEqual(expectedFormatted, actualFormated);
        }

        [Test]
        public void TestFormat_Null_Null()
        {
            Point point = null;

            string actualFormated = Formatter.Format(point);

            Assert.IsNull(actualFormated);
        }
    }
}
