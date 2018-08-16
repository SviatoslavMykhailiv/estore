﻿namespace estore.contracts.Models
{
    /// <summary>
    /// Defines a model that comes as response while success login
    /// </summary>
    public class LoginResponseModel
    {
        public LoginResponseModel(string token, string userId)
        {
            Token = token;
            UserId = userId;
        }

        /// <summary>
        /// Access token generated by token provider
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// User ID
        /// </summary>
        public string UserId { get; }
    }
}