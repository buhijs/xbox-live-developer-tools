﻿// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Xbox.Services.Tool
{
    /// <summary>
    ///  Class represents a developer account.
    /// </summary>
    public class DevAccount
    {
        /// <summary>
        ///  ID of the developer account
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// User name of the developer account
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The Id of the account under which the developer is acting. Also known as publisher ID
        /// </summary>
        public string AccountId { get; private set; }

        /// <summary>
        /// The account type under which the developer is acting.
        /// </summary>
        public string AccountType { get; private set; }

        /// <summary>
        /// The moniker of the account for which the token is issued. 
        /// </summary>
        public string AccountMoniker { get; private set; }

        /// <summary>
        /// The account source where the account was registered.
        /// </summary>
        public DevAccountSource AccountSource { get; internal set; }

        internal DevAccount(XdtsTokenResponse etoken, DevAccountSource accountSource)
        {
            object value;
            if (etoken.DisplayClaims.TryGetValue("eid", out value))
            {
                this.Id = value.ToString();
            }

            if (etoken.DisplayClaims.TryGetValue("enm", out value))
            {
                this.Name = value.ToString();
            }

            if (etoken.DisplayClaims.TryGetValue("eai", out value))
            {
                this.AccountId = value.ToString();
            }

            if (etoken.DisplayClaims.TryGetValue("eam", out value))
            {
                this.AccountMoniker = value.ToString();
            }

            if (etoken.DisplayClaims.TryGetValue("eat", out value))
            {
                this.AccountType = value.ToString();
            }

            this.AccountSource = accountSource;
        }
    }
}
