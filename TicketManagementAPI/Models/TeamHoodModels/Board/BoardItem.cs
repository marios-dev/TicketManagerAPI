using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TicketManagementAPI.Interfaces;

namespace TicketManagementAPI.Models.TeamHoodModels.Board
{
    public class BoardItem : IBoardItemService
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("boardId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? BoardId { get; set; }

        [JsonProperty("assignedUserId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? AssignedUserId { get; set; }

        [JsonProperty("ownerId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? OwnerId { get; set; }

        [JsonProperty("rowId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? RowId { get; set; }

        [JsonProperty("statusId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? StatusId { get; set; }

        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartDate { get; set; }

        [JsonProperty("dueDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DueDate { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public long? Color { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("budget", NullValueHandling = NullValueHandling.Ignore)]
        public long? Budget { get; set; }

        [JsonProperty("estimation", NullValueHandling = NullValueHandling.Ignore)]
        public long? Estimation { get; set; }

        [JsonProperty("completed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Completed { get; set; }

        [JsonProperty("workspaceId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? WorkspaceId { get; set; }

        [JsonProperty("milestone", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Milestone { get; set; }

        [JsonProperty("progress", NullValueHandling = NullValueHandling.Ignore)]
        public long? Progress { get; set; }

        [JsonProperty("customFields", NullValueHandling = NullValueHandling.Ignore)]
        public List<CustomField> CustomFields { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tags { get; set; }

        public void AddNewItem()
        {
            throw new NotImplementedException();
        }

        public void DeleteNewItem()
        {
            throw new NotImplementedException();
        }

        public void UpdateNewItem()
        {
            throw new NotImplementedException();
        }
    }

    public partial class CustomField
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}
