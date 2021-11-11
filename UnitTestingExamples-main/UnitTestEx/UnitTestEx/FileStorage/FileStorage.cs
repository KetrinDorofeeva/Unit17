using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTestEx
{
    public class FileStorage
    {
        private List<File> files = new List<File>();
        private double availableSize = 100;
        private double maxSize = 100;

        /**
         * Construct object and set max storage size and available size according passed values
         * @param size FileStorage size
         */
        public FileStorage(int size) {
            maxSize = size;
            availableSize += maxSize;
        }

        /**
         * Construct object and set max storage size and available size based on default value=100
         */
        public FileStorage() { }


        /**
         * Write file in storage if filename is unique and size is not more than available size
         * @param file to save in file storage
         * @return result of file saving
         * @throws FileNameAlreadyExistsException in case of already existent filename
         */
        public bool Write(File file) {
            // Проверка существования файла
            if (IsExists(file.GetFilename())) {
                //Если файл уже есть, то кидаем ошибку
                throw new FileNameAlreadyExistsException();
            }

            //Проверка того, размер файла не привышает доступный объем памяти
            if (file.GetSize() >= availableSize) {
                return false;
            }

            // Добаляем файл в лист
            files.Add(file);
            // Добаляем файл в лист
            availableSize -= file.GetSize();

            return true;
        }

        /**
         * Check is file exist in storage
         * @param fileName to search
         * @return result of checking
         */
        public bool IsExists(string fileName) {
            // Для каждого элемента с типом File из Листа files
            foreach (var file in files) {
                // Проверка имени
                if (file.GetFilename().Contains(fileName)) {
                    return true;
                }
            }
            return false;
        }

        /**
         * Delete file from storage
         * @param fileName of file to delete
         * @return result of file deleting
         */
        public bool Delete(string fileName) {
            return files.Remove(GetFile(fileName));
        }

        /**
         * Get all Files saved in the storage
         * @return list of files
         */
        public List<File> GetFiles() {
            return files;
        }

        /**
         * Get file by filename
         * @param fileName of file to get
         * @return file
         */
        public File GetFile(string fileName) {
            if (IsExists(fileName))
            {
                return files.First(file => file.GetFilename().Equals(fileName));
            }
                
            throw new FileNotFoundException();
        }

        /**
         * Delete all files from files list
         * @return bool
         */
        public bool DeleteAllFiles()
        {
            files.Clear();

            return files.Count == 0;
        }

    }
}