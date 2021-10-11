using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace codelou_2021_jeopardy
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var clues = client.GetStringAsync("https://jservice.io/api/clues").Result;
           
            var allClues = JsonConvert.DeserializeObject<List<Clue>>(clues);
            Console.WriteLine(clues);

            var longQuestions = allClues.Where(clue => clue.question.Length > 50).ToList();
            
            // Converting List<Clues> to a string
            string serializedQuestions = JsonConvert.SerializeObject(longQuestions);

            var path = System.Environment.CurrentDirectory + "/question.json";

            System.IO.File.WriteAllText(path , serializedQuestions);
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Category
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int clues_count { get; set; }
    }

    public class Clue
    {
        public int id { get; set; }
        public string answer { get; set; }
        public string question { get; set; }
        public int? value { get; set; }
        public DateTime airdate { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int category_id { get; set; }
        public object game_id { get; set; }
        public object invalid_count { get; set; }
        public Category category { get; set; }
    }

   


}
