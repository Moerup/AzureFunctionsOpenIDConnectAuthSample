﻿using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace OidcApiAuthorization.Abstractions
{
    /// <summary>
    /// Encapsulates the results of an API authorization.
    /// </summary>
    public class ApiAuthorizationResult
    {
        /// <summary>
        /// Constructs a success authorization.
        /// </summary>
        /// <param name="claimsPrincipal">
        /// The authorized ClaimsPrincipal.
        /// </param>
        /// <param name="securityToken">
        /// The authorized SecurityToken
        /// </param>
        public ApiAuthorizationResult(ClaimsPrincipal claimsPrincipal, SecurityToken securityToken)
        {
            ClaimsPrincipal = claimsPrincipal;
            SecurityToken = securityToken;
        }

        /// <summary>
        /// Constructs a failed authorization with given reason.
        /// </summary>
        /// <param name="failureReason">
        /// Describes the reason for the authorization failure.
        /// </param>
        public ApiAuthorizationResult(string failureReason)
        {
            FailureReason = failureReason;
        }

        /// <summary>
        /// The authorized ClaimsPrincipal or null if authorization failed.
        /// </summary>
        public ClaimsPrincipal ClaimsPrincipal { get; }


        /// <summary>
        /// String describing the reason for the authorization failure.
        /// </summary>
        public string FailureReason { get; }

        /// <summary>
        /// The authorized SecurityToken or null if authorization failed.
        /// </summary>
        public SecurityToken SecurityToken { get; }

        /// <summary>
        /// True if authorization was successful.
        /// </summary>
        public bool Success => ClaimsPrincipal != null && string.IsNullOrEmpty(FailureReason);
    }
}
