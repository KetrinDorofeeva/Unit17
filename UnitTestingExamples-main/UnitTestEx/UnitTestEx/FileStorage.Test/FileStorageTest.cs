using UnitTestEx;
using Xunit;
using File = UnitTestEx.File;
using Storage = UnitTestEx.FileStorage;

namespace FileStorage.Tests
{
	public class FileStorageTest
	{
		private const string FILE_NAME = "FileName";
		private const string CONTENT = "Content";
		private const int CLEAR_STORAGE = 150;

		private const string SIZE_CONTENT_STRING = "TEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtext";

		/* ПРОВАЙДЕРЫ */
		private Storage ClearStorage => new(CLEAR_STORAGE);
		private File FileName => new(FILE_NAME, CONTENT);


		/* Тестирование записи файла */
		[Fact]
		public void WriteTest()
		{
			// Arrange
			var storage = ClearStorage;
			var file = FileName;

			// Assert
			Assert.True(storage.Write(file));
		}

		/* Тестирование записи дублирующегося файла */
		[Fact]
		public void WriteExceptionTest()
		{
			// Arrange
			var storage = ClearStorage;
			var file = FileName;

			// Act
			storage.Write(file);

			// Assert
			Assert.Throws<FileNameAlreadyExistsException>(() => storage.Write(file));
		}

		/* Тестирование проверки существования файла */
		[Fact]
		public void IsExistsTest()
		{
			// Arrange
			var storage = ClearStorage;
			var file = FileName;
			storage.Write(file);

			// Assert
			Assert.True(storage.IsExists(file.GetFilename()));
		}

		/* Тестирование удаления файла */
		[Fact]
		public void DeleteTest()
		{
			// Arrange
			var storage = ClearStorage;
			var file = FileName;
			storage.Write(file);

			// Assert
			Assert.True(storage.Delete(file.GetFilename()));
		}

		/* Тестирование получения файлов */
		[Fact]
		public void GetFilesTest()
		{
			// Arrange
			var storage = ClearStorage;

			// Act
			var files = storage.GetFiles();

			// Assert
			Assert.NotNull(files);
		}

		/* Тестирование получения файла */
		[Fact]
		public void GetFileTest()
		{
			// Arrange
			var storage = ClearStorage;
			var file = FileName;
			storage.Write(file);

			// Act
			var actual = storage.GetFile(file.GetFilename());

			// Assert
			Assert.Equal(file, actual);
		}

/////////////////////////////////* Дополнительные тесты *////////////////////////////////////////

		/* Тестирование проверки, что файл не существует */
		[Fact]
		public void IsNotExistsTest()
		{
			// Arrange
			var storage = ClearStorage;
			var file = FileName;

			// Assert
			Assert.False(storage.IsExists(file.GetFilename()));
		}

		/* Тестирование записи файла большого размера */
		[Fact]
		public void WriteBigSizeTest()
		{
			// Arrange
			var storage = new Storage();
			var file = new File(FILE_NAME, SIZE_CONTENT_STRING);

			// Assert
			Assert.False(storage.Write(file));
		}

		/* Тестирование удаления всех файлов */
		[Fact]
		public void DeleteAllFilesTest()
		{
			// Arrange
			var storage = ClearStorage;
			var file = FileName;
			storage.Write(file);

			// Act
			storage.DeleteAllFiles();

			// Assert
			Assert.NotNull(storage.GetFiles());
		}
	}
}