﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                              ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                            ▄██▀▀▀███▀▀▀██▄
      █     ███    █▀     ▄█████  ▄██████ ██   █     █████  █      ██    ▄█   ▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███          ██   █  ██    ██ ██   ██   ██  ██ ██  ▀███████▄ ██   █▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀███████████  ▄██▄▄    ██    ▀  ██   ██  ▄██▄▄█▀ ██▌     ██  ▀ ▀▀▀▀▀██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █            ███ ▀▀██▀▀    ██    ▄  ██   ██ ▀███████ ██      ██    ▄█   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █      ▄█    ███   ██   █  ██    ██ ██   ██   ██  ██ ██      ██    ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █    ▄████████▀    ███████ ██████▀  ██████    ██  ██ █      ▄██▀    █████    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Manages the security subsystem.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.Owin.Security;
using NLog;
using NLog.xLogger;
using OpenIIoT.Core.Common;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Discovery;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Configuration;
using Utility.OperationResult;
using OpenIIoT.SDK.Common.Provider.EventProvider;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security
{
    /// <summary>
    ///     Manages the security subsystem.
    /// </summary>
    [Discoverable]
    public class SecurityManager : Manager, ISecurityManager, IConfigurable<SecurityManagerConfiguration>
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of PlatformManager.
        /// </summary>
        private static ISecurityManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <param name="manager">The IApplicationManager instance for the application.</param>
        /// <param name="configurationManager">The IConfigurationManager instance for the application.</param>
        private SecurityManager(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            base.logger = logger;
            Guid guid = logger.EnterMethod();

            ManagerName = "Security Manager";
            EventProviderName = GetType().Name;

            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IConfigurationManager>(configurationManager);

            SessionList = new List<Session>();
            UserList = new List<User>();

            ChangeState(State.Initialized);

            logger.ExitMethod(guid);
        }

        #endregion Private Constructors

        #region Public Events

        /// <summary>
        ///     Occurs when a Session is ended.
        /// </summary>
        [Event(Description = "Occurs when a Session is ended.")]
        public event EventHandler<SessionEventArgs> SessionEnded;

        /// <summary>
        ///     Occurs when a Session is started.
        /// </summary>
        [Event(Description = "Occurs when a Session is started.")]
        public event EventHandler<SessionEventArgs> SessionStarted;

        /// <summary>
        ///     Occurs when a User is created.
        /// </summary>
        [Event(Description = "Occurs when a User is created.")]
        public event EventHandler<UserEventArgs> UserCreated;

        /// <summary>
        ///     Occurs when a User is deleted.
        /// </summary>
        [Event(Description = "Occurs when a User is deleted.")]
        public event EventHandler<UserEventArgs> UserDeleted;

        /// <summary>
        ///     Occurs when a User is updated.
        /// </summary>
        [Event(Description = "Occurs when a User is updated.")]
        public event EventHandler<UserEventArgs> UserUpdated;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        ///     Gets the Configuration for the Manager.
        /// </summary>
        public SecurityManagerConfiguration Configuration { get; private set; }

        /// <summary>
        ///     Gets the ConfigurationDefinition for the Manager.
        /// </summary>
        public IConfigurationDefinition ConfigurationDefinition => GetConfigurationDefinition();

        /// <summary>
        ///     Gets the list of built-in <see cref="Role"/> s.
        /// </summary>
        public IReadOnlyList<Role> Roles => new[] { Role.Reader, Role.ReadWriter, Role.Administrator }.ToList();

        /// <summary>
        ///     Gets the list of active <see cref="Session"/> s.
        /// </summary>
        public IReadOnlyList<Session> Sessions => ((List<Session>)SessionList).AsReadOnly();

        /// <summary>
        ///     Gets the list of configured <see cref="User"/> s.
        /// </summary>
        public IReadOnlyList<User> Users => ((List<User>)UserList).AsReadOnly();

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets or sets the list of active <see cref="Session"/> s.
        /// </summary>
        private IList<Session> SessionList { get; set; }

        /// <summary>
        ///     Gets or sets the list of configured <see cref="User"/> s.
        /// </summary>
        private IList<User> UserList { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Returns the ConfigurationDefinition for the Model Manager.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Model Manager.</returns>
        public static IConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(SecurityManagerConfiguration);

            SecurityManagerConfiguration config = new SecurityManagerConfiguration();
            config.Users.Add(new User(GetDefaultUser(), GetDefaultUserPasswordHash(), Role.Administrator));

            retVal.DefaultConfiguration = config;

            return retVal;
        }

        /// <summary>
        ///     Instantiates and/or returns the SecurityManager instance.
        /// </summary>
        /// <remarks>
        ///     Invoked via reflection from ApplicationManager. The parameters are used to build an array of IManager parameters
        ///     which are then passed to this method. To specify additional dependencies simply insert them into the parameter list
        ///     for the method and they will be injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The IApplicationManager instance for the application.</param>
        /// <param name="configurationManager">The IConfigurationManager instance for the application.</param>
        /// <returns>The Singleton instance of PlatformManager.</returns>
        public static ISecurityManager Instantiate(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            if (instance == null)
            {
                instance = new SecurityManager(manager, configurationManager);
            }

            return instance;
        }

        /// <summary>
        ///     Terminates Singleton instance of PlatformManager.
        /// </summary>
        public static void Terminate()
        {
            instance = null;
        }

        /// <summary>
        ///     Configures the Manager using the configuration stored in the Configuration Manager, or, failing that, using the
        ///     default configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure()
        {
            logger.EnterMethod();
            logger.Debug("Attempting to Configure with the configuration from the Configuration Manager...");
            Result retVal = new Result();

            IResult<SecurityManagerConfiguration> fetchResult = Dependency<IConfigurationManager>().Configuration.GetInstance<SecurityManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.
            if (fetchResult.ResultCode != ResultCode.Failure)
            {
                logger.Debug("Successfully fetched the configuration from the Configuration Manager.");
                Configure(fetchResult.ReturnValue);
            }
            else
            {
                // if the fetch failed, add a new default instance to the configuration and try again.
                logger.Debug("Unable to fetch the configuration.  Adding the default configuration to the Configuration Manager...");
                IResult<SecurityManagerConfiguration> createResult = Dependency<IConfigurationManager>().Configuration.AddInstance<SecurityManagerConfiguration>(this.GetType(), GetConfigurationDefinition().DefaultConfiguration);
                if (createResult.ResultCode != ResultCode.Failure)
                {
                    logger.Debug("Successfully added the configuration.  Configuring...");
                    Configure(createResult.ReturnValue);
                }
                else
                {
                    retVal.Incorporate(createResult);
                }
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Configures the Manager using the supplied configuration, then saves the configuration to the Model Manager.
        /// </summary>
        /// <param name="configuration">The configuration with which the Manager should be configured.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure(SecurityManagerConfiguration configuration)
        {
            logger.EnterMethod(xLogger.Params(configuration));

            Result retVal = new Result();

            Configuration = configuration;
            UserList = Configuration.Users;

            logger.Debug("Successfully configured the Manager.");

            logger.Debug("Saving the new configuration...");
            retVal.Incorporate(SaveConfiguration());

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Creates a new <see cref="User"/>.
        /// </summary>
        /// <param name="name">The name of the new User.</param>
        /// <param name="password">The plaintext password for the new User.</param>
        /// <param name="role">The Role for the new User.</param>
        /// <returns>A Result containing the result of the operation and the newly created User.</returns>
        public IResult<User> CreateUser(string name, string password, Role role)
        {
            logger.EnterMethod(xLogger.Params(name, xLogger.Exclude(), role));
            logger.Info($"Creating new User '{name}' with Role '{role}'...");

            IResult<User> retVal = new Result<User>();
            retVal.ReturnValue = default(User);

            if (FindUser(name) == default(User))
            {
                retVal.ReturnValue = new User(name, SDK.Common.Utility.ComputeSHA512Hash(password), role);
                UserList.Add(retVal.ReturnValue);
            }
            else
            {
                retVal.AddError($"User '{name}' already exists.");
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to create User '{name}'.");
            }
            else
            {
                Task.Run(() => UserCreated?.Invoke(this, new UserEventArgs(retVal.ReturnValue)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Deletes the specified <see cref="User"/> from the list of <see cref="Users"/>.
        /// </summary>
        /// <param name="name">The name of the User to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult DeleteUser(string name)
        {
            logger.EnterMethod(xLogger.Params(name));
            logger.Info($"Deleting User '{name}'...");

            IResult retVal = new Result();
            User foundUser = FindUser(name);

            if (foundUser != default(User))
            {
                UserList.Remove(foundUser);
            }
            else
            {
                retVal.AddError($"User '{name}' does not exist.");
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to delete User '{name}'.");
            }
            else
            {
                Task.Run(() => UserDeleted?.Invoke(this, new UserEventArgs(foundUser)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Ends the specified <see cref="Session"/>.
        /// </summary>
        /// <param name="session">The Session to end.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult EndSession(Session session)
        {
            logger.EnterMethod();
            logger.Debug($"Ending Session '{session.ApiKey}'...");

            IResult retVal = new Result();
            Session foundSession = FindSession(session.ApiKey);

            if (foundSession != default(Session))
            {
                SessionList.Remove(foundSession);
            }
            else
            {
                retVal.AddError($"Session matching ApiKey '{session.ApiKey}' does not exist.");
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to end Session.");
            }
            else
            {
                Task.Run(() => SessionEnded?.Invoke(this, new SessionEventArgs(foundSession)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Finds the <see cref="Session"/> matching the specified <paramref name="apiKey"/>.
        /// </summary>
        /// <param name="apiKey">The ApiKey for the requested Session.</param>
        /// <returns>The found Session.</returns>
        public Session FindSession(string apiKey)
        {
            return SessionList
                .Where(s => s.Ticket.Identity.Claims
                    .Where(c => c.Type == ClaimTypes.Hash).FirstOrDefault().Value == apiKey).FirstOrDefault();
        }

        /// <summary>
        ///     Finds the <see cref="User"/> matching the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the requested User.</param>
        /// <returns>The found User.</returns>
        public User FindUser(string name)
        {
            return UserList.Where(u => u.Name == name).FirstOrDefault();
        }

        /// <summary>
        ///     Finds the <see cref="Session"/> belonging to the specified <see cref="User"/>.
        /// </summary>
        /// <param name="user">The User for which the Session is to be retrieved.</param>
        /// <returns>The found Session.</returns>
        public Session FindUserSession(User user)
        {
            return SessionList
                .Where(s => s.Ticket.Identity.Claims
                    .Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value == user.Name).FirstOrDefault();
        }

        /// <summary>
        ///     Saves the configuration to the Configuration Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult SaveConfiguration()
        {
            logger.EnterMethod();
            Result retVal = new Result();

            Configuration.Users = UserList;

            retVal.Incorporate(Dependency<IConfigurationManager>().Configuration.UpdateInstance(this.GetType(), Configuration));

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Starts a new <see cref="Session"/> with the specified <paramref name="userName"/> and <paramref name="password"/>
        /// </summary>
        /// <param name="userName">The user for which the Session is to be started.</param>
        /// <param name="password">The password with which to authenticate the user.</param>
        /// <returns>A Result containing the result of the operation and the created Session.</returns>
        public IResult<Session> StartSession(string userName, string password)
        {
            logger.EnterMethod(xLogger.Params(userName, xLogger.Exclude()));
            logger.Info($"Starting Session for User '{userName}'...");

            IResult<Session> retVal = new Result<Session>();

            User foundUser = FindUser(userName);

            if (foundUser != default(User))
            {
                string hash = SDK.Common.Utility.ComputeSHA512Hash(password);

                if (foundUser.PasswordHash == hash)
                {
                    Session foundSession = FindUserSession(foundUser);

                    if (foundSession == default(Session))
                    {
                        retVal.ReturnValue = CreateSession(foundUser);
                        SessionList.Add(retVal.ReturnValue);
                    }
                    else
                    {
                        retVal.AddWarning($"The specified User has an existing Session.  The existing Session is being returned.");
                        retVal.ReturnValue = foundSession;
                    }
                }
                else
                {
                    retVal.AddError($"Supplied password does not match.");
                }
            }
            else
            {
                retVal.AddError($"User '{userName}' does not exist.");
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to start Session for User '{userName}'.");
            }
            else
            {
                if (retVal.ResultCode == ResultCode.Success)
                {
                    Task.Run(() => SessionStarted?.Invoke(this, new SessionEventArgs(retVal.ReturnValue)));
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        public IResult<User> UpdateUser(User user, string password = null, Role role = Role.NotSpecified)
        {
            logger.EnterMethod(xLogger.Params(user, xLogger.Exclude(), role));
            IResult<User> retVal = new Result<User>();

            User foundUser = FindUser(user.Name);

            if (foundUser != default(User))
            {
                if (password != null)
                {
                    foundUser.PasswordHash = SDK.Common.Utility.ComputeSHA512Hash(password);
                }

                if (role != Role.NotSpecified)
                {
                    foundUser.Role = role;
                }
            }
            else
            {
                retVal.AddError($"Failed to find User '{user}'.");
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                retVal.ReturnValue = foundUser;
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Implements the post-instantiation procedure for the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <remarks>This method is invoked by the ApplicationManager following the instantiation of all program Managers.</remarks>
        /// <exception cref="ManagerSetupException">Thrown when an error is encountered during setup.</exception>
        protected override void Setup()
        {
        }

        /// <summary>
        ///     Implements the shutdown procedure for the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <param name="stopType">The <see cref="StopType"/> enumeration corresponding to the nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            IResult retVal = new Result();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Implements the startup procedure for the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <exception cref="DirectoryException">Thrown when one or more application directories can not be verified.</exception>
        protected override IResult Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");

            IResult retVal = Configure();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        private static string GetDefaultUser()
        {
            return Utility.GetSetting<string>("DefaultUser", "admin");
        }

        private static string GetDefaultUserPasswordHash()
        {
            return Utility.GetSetting<string>("DefaultUserPasswordHash", "C7AD44CBAD762A5DA0A452F9E854FDC1E0E7A52A38015F23F3EAB1D80B931DD472634DFAC71CD34EBC35D16AB7FB8A90C81F975113D6C7538DC69DD8DE9077EC");
        }

        private static int SessionLength()
        {
            return Utility.GetSetting<int>("SessionLength", "30");
        }

        private Session CreateSession(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity("ApiKey");
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));

            string hash = SDK.Common.Utility.ComputeSHA512Hash(Guid.NewGuid().ToString());

            identity.AddClaim(new Claim(ClaimTypes.Hash, hash));

            AuthenticationProperties ticketProperties = new AuthenticationProperties();
            ticketProperties.IssuedUtc = DateTime.UtcNow;
            ticketProperties.ExpiresUtc = DateTime.UtcNow.AddMinutes(SessionLength());

            AuthenticationTicket ticket = new AuthenticationTicket(identity, ticketProperties);

            return new Session(hash, ticket);
        }

        #endregion Private Methods
    }
}