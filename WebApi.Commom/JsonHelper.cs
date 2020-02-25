using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebApi.Common
{


    public static class JsonHelper
    {
        private const Double ChacheExpirationInMinutes = 10;
        public static string GeneralFilePath(string fileName)
        {
            return fileName + ".json";
        }


        /// <summary>
        /// Writes the given object instance to a Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var fileName = GeneralFilePath(filePath);
                var directory = fileName.Remove(fileName.LastIndexOf('\\') + 1);
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                WriteJsonFile(contentsToWriteToFile, directory, fileName);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        /// 

        public static bool ReadFromJsonFile<T>(string filePath, out T value) where T : new()
        {
            TextReader reader = null;

            try
            {
                var path = GeneralFilePath(filePath);
                if (!File.Exists(path))
                {
                    value = default(T);
                    return false;
                }
                reader = new StreamReader(path);
                var fileContents = reader.ReadToEnd();
                value = JsonConvert.DeserializeObject<T>(fileContents);
                return true; ;

            }
            catch (Exception e)
            {
                value = default(T);
                return false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }


        /// <summary>Used to Create Random Password</summary>
        /// <param name="PasswordLength"> Length of the Password </param>
        /// <returns> returns Generated Pasword String </returns>
        public static void WriteJsonFile(string content, string strDirectoryPath, string strFilePath)
        {
            if (Directory.Exists(strDirectoryPath))
            {
                if (!System.IO.File.Exists(strFilePath))
                    using (FileStream fs = new FileStream(strFilePath, FileMode.Create))
                    {
                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                        {
                            w.Write(content);
                        }
                    }

                else if (File.Exists(strFilePath))
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(strFilePath);

                    //Write a line of text
                    sw.Write(content);

                    //Close the file
                    sw.Close();

                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(strDirectoryPath);
                if (!System.IO.File.Exists(strFilePath))
                    using (FileStream fs = new FileStream(strFilePath, FileMode.Create))
                    {
                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                        {
                            w.Write(content);
                        }
                    }
            }
        }



    }
}
