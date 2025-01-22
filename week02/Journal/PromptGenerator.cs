using System;


public class PromptGenerator{
    public string[] _prompts = {
        "What did you improve at today?",
        "What was something cool that happened today?",
        "What was the best part of your day?",
        "What made you angry today?",
        "What made you smile today?"
    };

    public string GetRandomPrompt(){
        Random random = new Random();
        int index = random.Next(0, _prompts.Length - 1);
        return _prompts[index];
    }
}