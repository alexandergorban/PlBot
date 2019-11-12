using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
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
        public static string DialogStateId { get; } = $"{nameof(BotStateService)}.DialogState";

        // Accessors
        public IStatePropertyAccessor<ConversationData> ConversationDataAccessor { get; set; }
        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }
        public IStatePropertyAccessor<DialogState> DialogStateAccessor { get; set; }

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
            DialogStateAccessor = ConversationState.CreateProperty<DialogState>(DialogStateId);

            // Initialize User State
            UserProfileAccessor = UserState.CreateProperty<UserProfile>(UserProfileId);
        }
    }
}
