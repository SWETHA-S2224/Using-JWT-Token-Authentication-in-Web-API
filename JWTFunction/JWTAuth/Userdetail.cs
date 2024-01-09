// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Runtime.InteropServices.Marshalling;
// using Microsoft.IdentityModel.Tokens;

// public class Userdetail
// {
//     private List<User> users;
//     public Userdetail()
//     {
       
//         users = new List<User>
//         {
//              new User { UserName = "swe", Password = "swe333", Email = "swetha@gmail.com" },
//             new User { UserName= "Niha", Password = "Niha", Email = "niha@gmail.com" }
//         };
//     }
//         public User GetUserDetails(string userName)
//     {
//         // Find the user with the specified ID
//         User user = users.Find(u => u.UserName == userName);

//         // Check if the user was found
//         if (user != null)
//         {
//             // Return user details
//             return user;
//         }
//         else
//         {
//             // Handle the case where the user was not found
//             Console.WriteLine($"User with Name {userName} not found.");
//             return null; // Or throw an exception, depending on your application logic
//         }
//     }
// }
 