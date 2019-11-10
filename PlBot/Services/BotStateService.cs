using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using PlBot.Models;

namespace PlBot.Services
{
    public class BotStateService
    {
        #region Variables
        // State Variables
        public ConversationState ConversationState { get; }
        public UserState UserState { get; set; }

        // IDs
        public static string ConversationDateId { get; } = $"{nameof(BotStateService)}.ConversationDate";
        public static string UserProfileId { get; } = $"{nameof(BotStateService)}.UserProfile";

        // Accessors
        public IStatePropertyAccessor<ConversationData> ConversationDataAccessor { get; set; }
        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }

        #endregion

        public BotStateService(ConversationState conversationState, UserState userState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
            UserState = userState ?? throw new ArgumentNullException(nameof(userState));

            InitializeAccessors();
        }

        public void InitializeAccessors()
        {
            // Initialize Conversation State Accessors
            ConversationDataAccessor = ConversationState.CreateProperty<ConversationData>(ConversationDateId);

            // Initialize User State
            UserProfileAccessor = UserState.CreateProperty<UserProfile>(UserProfileId);
        }
    }
}
