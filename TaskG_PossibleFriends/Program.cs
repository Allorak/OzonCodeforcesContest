using System;
using System.Collections.Generic;
using System.Linq;

var usersAndPairsAmount = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (userAmount, pairAmount) = (usersAndPairsAmount[0], usersAndPairsAmount[1]);

var friendsDictionary = new Dictionary<int, List<int>>();
for (var i = 1; i <= userAmount; i++)
{
    friendsDictionary[i] = new List<int>();
}
var sharedFriendsMatrix = new int [userAmount, userAmount];
var maximumPossibleFriends = new Dictionary<int, int>();
for (var i = 1; i <= userAmount; i++)
{
    maximumPossibleFriends[i] = 0;
}

for (var pairIndex = 0; pairIndex < pairAmount; pairIndex++)
{
    var pair = Console.ReadLine().Split().Select(int.Parse).ToArray();
    friendsDictionary[pair[0]].Add(pair[1]);
    friendsDictionary[pair[1]].Add(pair[0]);
}
/*
for (var i = 1; i <= userAmount; i++)
{
    for (var j = i+1; j <= userAmount; j++)
    {
        foreach (var friend in friendsDictionary[j].Where(friend => friend != i && !friendsDictionary[i].Contains(friend)))
        {
            sharedFriendsMatrix[i - 1, friend - 1] += 1;
            sharedFriendsMatrix[friend - 1, i - 1] += 1;
            if (sharedFriendsMatrix[i - 1, friend - 1] > maximumPossibleFriends[i])
                maximumPossibleFriends[i] = sharedFriendsMatrix[i - 1, friend - 1];
            if (sharedFriendsMatrix[friend - 1, i - 1] > maximumPossibleFriends[friend])
                maximumPossibleFriends[friend] = sharedFriendsMatrix[friend - 1, i - 1];
        }
    }
}*/

for (var i = 1; i <= userAmount; i++)
{
    foreach (var relativeFriend in friendsDictionary[i].SelectMany(friend => friendsDictionary[friend].Where(x => x!=i && !friendsDictionary[i].Contains(x))))
    {
        sharedFriendsMatrix[relativeFriend - 1, i - 1] += 1;
        sharedFriendsMatrix[i - 1, relativeFriend - 1] += 1;
        maximumPossibleFriends[relativeFriend] = Math.Max(maximumPossibleFriends[relativeFriend],
            sharedFriendsMatrix[relativeFriend - 1, i - 1]);
        maximumPossibleFriends[i] = Math.Max(maximumPossibleFriends[i],
            sharedFriendsMatrix[i - 1, relativeFriend - 1]);
        
    }
}

for (var i = 1; i <= userAmount; i++)
{
    if(maximumPossibleFriends[i] == 0)
        Console.WriteLine(0);
    else
    {
        for (var j = 0; j < userAmount; j++)
        {
            if (sharedFriendsMatrix[i - 1, j] == maximumPossibleFriends[i])
                Console.Write(j + 1 + " ");
        }

        Console.WriteLine();
    }
}