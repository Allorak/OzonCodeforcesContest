var amountOfUsersAndRequests = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (userAmount, requestAmount) = (amountOfUsersAndRequests[0], amountOfUsersAndRequests[1]);
var lastMessages = new Dictionary<int,int>();
var lastMessageNumber = 0;
for (var i = 0; i < requestAmount; i++)
{
    var requestInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
    var (requestType, requestedUser) = (requestInfo[0], requestInfo[1]);
    switch (requestType)
    {
        case 1:
            SendMessage(requestedUser);
            break;
        case 2:
            Console.WriteLine(GetLastMessage(requestedUser));
            break;
    }
}

void SendMessage(int userId)
{
    lastMessageNumber++;
    if (userId != 0)
    {
        lastMessages[userId] = lastMessageNumber;
        return;
    }
    for (var i = 0; i < userAmount; i++)
    {
        lastMessages[i + 1] = lastMessageNumber;
    }
}

int GetLastMessage(int userId)
{
    return lastMessages.ContainsKey(userId) ? lastMessages[userId] : 0;
}