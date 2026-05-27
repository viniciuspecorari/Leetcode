string word = "abDBAbb";
int especialLetterCount = 0;

Dictionary<string, int> lowerEspecialLetterDict = new Dictionary<string, int>();
Dictionary<string, int> upperEspecialLetterDict = new Dictionary<string, int>();


for (int i = 0; i < word.Length; i++)
{
    if (char.IsLower(word[i]))
    {
        if(lowerEspecialLetterDict.TryAdd(word[i].ToString(), i))
        {

        }
        else
        {
            var upperletterExists = upperEspecialLetterDict.TryGetValue(word[i].ToString().ToUpper(), out int indexUpper);
            var lowerletterExists = lowerEspecialLetterDict.TryGetValue(word[i].ToString().ToLower(), out int indexLower);

            if (upperletterExists && lowerletterExists && indexLower < indexUpper)
            {
                especialLetterCount--;
                lowerEspecialLetterDict.Remove(word[i].ToString());
            }
                
        }
    }    

    if (char.IsUpper(word[i]))
    {
        if(upperEspecialLetterDict.TryAdd(word[i].ToString(), i))
        {
            Console.WriteLine($"Added upper letter: {word[i]} at index {i}");
            var lowerLletterExists = lowerEspecialLetterDict.TryGetValue(word[i].ToString().ToLower(), out int indexLower);
            if (lowerLletterExists && indexLower < i)
                especialLetterCount++;
        }           
    }
}

Console.WriteLine(especialLetterCount);