﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄██████▄                                                                           ▄████████
      █   ███    ███                                                                         ███    ███
      █   ███    ███    █████▄    ▄█████    █████   ▄█████      ██     █   ██████  ██▄▄▄▄   ▄███▄▄▄▄██▀    ▄█████   ▄█████ ██   █   █           ██
      █   ███    ███   ██   ██   ██   █    ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ▀▀███▀▀▀▀▀     ██   █    ██  ▀  ██   ██ ██       ▀███████▄
      █   ███    ███   ██   ██  ▄██▄▄     ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ▀███████████  ▄██▄▄      ██     ██   ██ ██           ██  ▀
      █   ███    ███ ▀██████▀  ▀▀██▀▀    ▀███████ ▀████████     ██    ██  ██    ██ ██   ██   ███    ███ ▀▀██▀▀    ▀███████ ██   ██ ██           ██
      █   ███    ███   ██        ██   █    ██  ██   ██   ██     ██    ██  ██    ██ ██   ██   ███    ███   ██   █     ▄  ██ ██   ██ ██▌    ▄     ██
      █    ▀██████▀   ▄███▀      ███████   ██  ██   ██   █▀    ▄██▀   █    ██████   █   █    ███    ███   ███████  ▄████▀  ██████  ████▄▄██    ▄██▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Encapsulates the result of any operation. Includes a result code and a list of messages generated during the operation.
      █
      █  Additional methods provide logging functionality for convenience, and a generic extension class is provided to allow for
      █  Result instances which contain an object as a return value.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The MIT License (MIT)
      █
      █  Copyright (c) 2016 JP Dillingham (jp@dillingham.ws)
      █
      █  Permission is hereby granted, free of charge, to any person obtaining a copy
      █  of this software and associated documentation files (the "Software"), to deal
      █  in the Software without restriction, including without limitation the rights
      █  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
      █  copies of the Software, and to permit persons to whom the Software is
      █  furnished to do so, subject to the following conditions:
      █
      █  The above copyright notice and this permission notice shall be included in all
      █  copies or substantial portions of the Software.
      █
      █  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
      █  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
      █  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
      █  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
      █  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
      █  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
      █  SOFTWARE.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using System.Runtime.Serialization;

namespace OpenIIoT.SDK.Common.OperationResult
{
    /// <summary>
    ///     Represents messages generated by operations.
    /// </summary>
    [DataContract]
    public class Message
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Message"/> class using the optionally supplied type with the
        ///     optionally supplied message.
        /// </summary>
        /// <param name="type">The type of the message.</param>
        /// <param name="text">The content of the message.</param>
        public Message(MessageType type = MessageType.Info, string text = "")
        {
            Type = type;
            Text = text;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the content of the message.
        /// </summary>
        [DataMember(Order = 2)]
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the type of the message.
        /// </summary>
        [DataMember(Order = 1)]
        public MessageType Type { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns a formatted string representation of the message.
        /// </summary>
        /// <returns>The formatted message string.</returns>
        public override string ToString()
        {
            return "[" + Type.ToString().ToUpper() + "] " + Text;
        }

        #endregion Public Methods
    }
}