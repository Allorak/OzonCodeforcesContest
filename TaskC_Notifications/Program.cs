var amountOfUsersAndRequests = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (userAmount, requestAmount) = (amountOfUsersAndRequests[0], amountOfUsersAndRequests[1]);
var lastMessage = new Dictionary<int,int>();
