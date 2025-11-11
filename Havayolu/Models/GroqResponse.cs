using System.Collections.Generic;

namespace Havayolu.Models
{
    public class GroqResponse
    {
        public List<Choice> Choices { get; set; }
    }

    public class Choice
    {
        public Message Message { get; set; }
    }

    public class Message
    {
        public string Content { get; set; }
        public string Role { get; set; }
    }
} 