using System.Collections.Generic;
using RutrackerManager.Common.Models;

namespace RutrackerManager.Api
{
    public static class TopicStatusHelper
    {
        public static TopicStatus GetStatus(this string token)
        {
            if (string.IsNullOrEmpty(token))
                return TopicStatus.Unknown;
            
            TopicStatus status;
            if (!TopicStatuses.TryGetValue(token.ToCharArray()[0], out status ))
                return TopicStatus.Unknown;
            return status;
        }

        public static Dictionary<char, TopicStatus> TopicStatuses = new Dictionary<char, TopicStatus>
            {
                {(char)8730, TopicStatus.Checked }, //'√'
                {'#', TopicStatus.Doubtful },     //'#'
                {'*', TopicStatus.NotChecked }     //'*'
            };
    }
}