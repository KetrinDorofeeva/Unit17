using UnitTestEx;
using Xunit;

namespace FileStorage.Test
{
    public class FileTest
    {
		private const string NAME_EXCEPTION = "FileName";
		private const string SIZE_EXCEPTION = "Size";

		/* Тестируем получение размера */
		[Fact]
		public void GetSizeTest()
		{
			// Arrange
			var file = new File(NAME_EXCEPTION, SIZE_EXCEPTION);
			var lenght = SIZE_EXCEPTION.Length / 2;

			//Act
			var newFile = file.GetSize();

			// Assert
			Assert.Equal(lenght, newFile);
		}


		/* Тестируем получение имени */
		[Fact]
		public void GetFilenameTest()
		{
			// Arrange
			var file = new File(NAME_EXCEPTION, SIZE_EXCEPTION);

			// Assert
			Assert.Equal(NAME_EXCEPTION, file.GetFilename());
		}
	}
}