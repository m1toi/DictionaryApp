using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DictionaryApp
{
    internal class DictionaryManager
    {
        public List<Word> words;
        public Dictionary<string, List<Word>> dictionary;
        public List<Word> randomWords;
        public DictionaryManager()
        {
            words = LoadDictionaryFromJson();
            SortWordsByCategory();
            randomWords = Get5RandomWords();
        }

        public List<Word> LoadDictionaryFromJson()
        {
           try
        {
            string json = File.ReadAllText("../../Dictionary.json");
            return JsonConvert.DeserializeObject<List<Word>>(json);
        }
            catch (FileNotFoundException)
        {
            return new List<Word>(); 
        }
        }

        public void SaveDictionaryToJson()
        {
            string json = JsonConvert.SerializeObject(words);
            File.WriteAllText("../../Dictionary.json", json);
        }   

        public void AddWord(Word word)
        {
            words.Add(word);
            SaveDictionaryToJson();
        }

        public void DeleteWord(Word word)
        {
            words.Remove(word);
            SaveDictionaryToJson();
        }
        public void ModifyWord(Word word, string description, string category, string imagepath)
        {
            word.ImagePath = imagepath;

            word.Description = description;
            word.Category = category;
            SaveDictionaryToJson();
        }

        public void SortWordsByCategory()
        {
            dictionary = new Dictionary<string, List<Word>>();
            dictionary.Add("-All-", new List<Word>());
            foreach (Word word in words)
            {
                if (!dictionary.ContainsKey(word.Category))
                {
                    
                    dictionary[word.Category] = new List<Word>();
                }
                dictionary[word.Category].Add(word);

                dictionary["-All-"].Add(word);
            }
        }


        public List<Word> Get5RandomWords()
        {
            Random rand = new Random();
            List<Word> randomWords = new List<Word>(words); 

            List<Word> selectedWords = new List<Word>();
            for (int i = 0; i < 6 && randomWords.Count > 0; i++)
            {
                int randomIndex = rand.Next(randomWords.Count);
                selectedWords.Add(randomWords[randomIndex]);
                randomWords.RemoveAt(randomIndex); 
            }

            return selectedWords;
        }

        

    }
}
