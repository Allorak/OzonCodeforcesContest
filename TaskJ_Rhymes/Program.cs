var dictionarySize = int.Parse(Console.ReadLine());
var dictionaryRoot = new List<Node>();
for (var i = 0; i < dictionarySize; i++)
{
    var word = Console.ReadLine();
    var currentNode = dictionaryRoot.FirstOrDefault(x => x.Letter == word[^1]);
    if (currentNode == null)
    {
        dictionaryRoot.Add(new Node(word[^1], null));
        currentNode = dictionaryRoot[^1];
    }
    for (var j = word.Length-2; j >= 0; j--)
    {
        if (!currentNode.ContainsNode(word[j]))
        {
            currentNode.AddNode(word[j]);
        }

        currentNode = currentNode.GetNextNode(word[j]);
    }

}

var requestAmount = int.Parse(Console.ReadLine());
for (var i = 0; i < requestAmount; i++)
{
    var word = Console.ReadLine();
    var suffixLength = 1;
    var nextNode = dictionaryRoot.FirstOrDefault(x => x.Letter == word[^suffixLength]);
    suffixLength++;
    if (nextNode is null)
    {
        Console.WriteLine(dictionaryRoot[0].BuildWord(true));
    }
    else
    {
        Node currentNode = null;
        while (suffixLength <= word.Length && nextNode is not null)
        {
            currentNode = nextNode;
            nextNode = nextNode.GetNextNode(word[^suffixLength]);
            suffixLength++;
        }

        var rhymedWord = "";
        if (nextNode is not null)
            rhymedWord = nextNode.BuildWord(true);
        else
            rhymedWord = currentNode.BuildWord(true);
        var random = new Random();
        while (rhymedWord == word)
        {
            rhymedWord = dictionaryRoot[random.Next(0, dictionaryRoot.Count)].BuildWord(true);
        } 
        Console.WriteLine(rhymedWord);
    }
}

class Node
{
    public char Letter { get; private set; }
    private List<Node> _nextNodes;
    private Node? _parent;

    public Node(char letter, Node parent)
    {
        Letter = letter;
        _nextNodes = new List<Node>();
        _parent = parent;
    }

    public void AddNode(char letter)
    {
        _nextNodes.Add(new Node(letter,this));
    }

    public Node GetNextNode(char letter)
    {
        return _nextNodes.FirstOrDefault(x => x.Letter == letter);
    }

    public bool ContainsNode(char letter)
    {
        return _nextNodes.Any(x => x.Letter == letter);
    }

    public string BuildWord(bool forward)
    {
        if (_nextNodes.Count > 0 && forward)
            return _nextNodes[0].BuildWord(true);
        if (_parent is null)
            return Letter.ToString();
        return Letter + _parent.BuildWord(false);
    }
}