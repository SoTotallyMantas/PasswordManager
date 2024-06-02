using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Util
{
    internal class FileOperations 
        
    {
        public void createFile(string path)
        {
           
                System.IO.File.Create(path).Close();

            
        }
        public  string GetAppDataPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PasswordManager";
        }

        public string GetAppDataPath(string fileName)
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PasswordManager\\" + fileName;
        }

        public string GetAppDataPath(string folderName, string fileName)
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PasswordManager\\" + folderName + "\\" + fileName;
        }

        public void CreateFolder(string path)
        {
            
                System.IO.Directory.CreateDirectory(path);
            
        }
        public void DeleteFolder(string path)
        {
            
               System.IO.Directory.Delete(path);
            
        }

        public void DeleteFile(string path)
        {
            
                System.IO.File.Delete(path);
            
        }
        public bool FileIsEmpty(string path)
        {
           
            return System.IO.File.ReadAllText(path).Length == 0;
            
        }
        public void SaveFile(string path, string data)
        {
            
                System.IO.File.WriteAllText(path, data);
            
        }

        public string ReadFile(string path)
        {
           
                return System.IO.File.ReadAllText(path);
            
        }

        public bool FileExists(string path)
        {
            
                return System.IO.File.Exists(path);
            
        }
        public void writeToFile(string path, string data)
        {
            
                System.IO.File.WriteAllText(path, data);
            
        }
 
    }
}
