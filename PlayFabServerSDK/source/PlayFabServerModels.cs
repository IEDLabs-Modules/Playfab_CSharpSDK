using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlayFab.ServerModels
{
	
	
	
	public class AddSharedGroupMembersRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers of users to add as members of the shared group
		/// </summary>
		public List<string> PlayFabIds { get; set;}
		
		
	}
	
	
	
	public class AddSharedGroupMembersResult
	{
		
		
		
	}
	
	
	
	public class AddUserVirtualCurrencyRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose virtual currency balance is to be incremented
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// name of the virtual currency which is to be incremented
		/// </summary>
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be added to the user balance of the specified virtual currency
		/// </summary>
		public int Amount { get; set;}
		
		
	}
	
	
	
	public class AuthenticateSessionTicketRequest
	{
		
		
		/// <summary>
		/// Session ticket as issued by a PlayFab client login API
		/// </summary>
		public string SessionTicket { get; set;}
		
		
	}
	
	
	
	public class AuthenticateSessionTicketResult
	{
		
		
		/// <summary>
		/// account info for the user whose session ticket was supplied
		/// </summary>
		public UserAccountInfo UserInfo { get; set;}
		
		
	}
	
	
	
	public class AwardSteamAchievementItem
	{
		
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique Steam achievement name
		/// </summary>
		public string AchievementName { get; set;}
		
		/// <summary>
		/// result of the award attempt (only valid on response, not on request)
		/// </summary>
		public bool Result { get; set;}
		
		
	}
	
	
	
	public class AwardSteamAchievementRequest
	{
		
		
		/// <summary>
		/// array of achievements to grant and the users to whom they are to be granted
		/// </summary>
		public List<AwardSteamAchievementItem> Achievements { get; set;}
		
		
	}
	
	
	
	public class AwardSteamAchievementResult
	{
		
		
		/// <summary>
		/// array of achievements granted
		/// </summary>
		public List<AwardSteamAchievementItem> AchievementResults { get; set;}
		
		
	}
	
	
	
	/// <summary>
	/// A purchasable item from the item catalog
	/// </summary>
	public class CatalogItem : IComparable<CatalogItem>
	{
		
		
		/// <summary>
		/// unique identifier for this item
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// class to which the item belongs
		/// </summary>
		public string ItemClass { get; set;}
		
		/// <summary>
		/// catalog item for this item
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// text name for the item, to show in-game
		/// </summary>
		public string DisplayName { get; set;}
		
		/// <summary>
		/// text description of item, to show in-game
		/// </summary>
		public string Description { get; set;}
		
		/// <summary>
		/// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
		/// </summary>
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// override prices for this item for specific currencies
		/// </summary>
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		/// <summary>
		/// list of item tags
		/// </summary>
		[Unordered]
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// game specific custom data
		/// </summary>
		public string CustomData { get; set;}
		
		/// <summary>
		/// array of ItemId values which are evaluated when any item is added to the player inventory - if all items in this array are present, the this item will also be added to the player inventory
		/// </summary>
		[Unordered]
		public List<string> GrantedIfPlayerHas { get; set;}
		
		/// <summary>
		/// defines the consumable properties (number of uses, timeout) for the item
		/// </summary>
		public CatalogItemConsumableInfo Consumable { get; set;}
		
		/// <summary>
		/// defines the container properties for the item - what items it contains, including random drop tables and virtual currencies, and what item (if any) is required to open it via the UnlockContainerItem API
		/// </summary>
		public CatalogItemContainerInfo Container { get; set;}
		
		/// <summary>
		/// defines the bundle properties for the item - bundles are items which contain other items, including random drop tables and virtual currencies
		/// </summary>
		public CatalogItemBundleInfo Bundle { get; set;}
		
		
		public int CompareTo(CatalogItem other)
        {
            if (other == null || other.ItemId == null) return 1;
            if (ItemId == null) return -1;
            return ItemId.CompareTo(other.ItemId);
        }
		
	}
	
	
	
	public class CatalogItemBundleInfo
	{
		
		
		/// <summary>
		/// unique ItemId values for all items which will be added to the player inventory when the bundle is added
		/// </summary>
		[Unordered]
		public List<string> BundledItems { get; set;}
		
		/// <summary>
		/// unique TableId values for all RandomResultTable objects which are part of the bundle (random tables will be resolved and add the relevant items to the player inventory when the bundle is added)
		/// </summary>
		[Unordered]
		public List<string> BundledResultTables { get; set;}
		
		/// <summary>
		/// virtual currency types and balances which will be added to the player inventory when the bundle is added
		/// </summary>
		public Dictionary<string,uint> BundledVirtualCurrencies { get; set;}
		
		
	}
	
	
	
	public class CatalogItemConsumableInfo
	{
		
		
		/// <summary>
		/// number of times this object can be used, after which it will be removed from the player inventory
		/// </summary>
		public uint? UsageCount { get; set;}
		
		/// <summary>
		/// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed
		/// </summary>
		public uint? UsagePeriod { get; set;}
		
		/// <summary>
		/// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values added together, and share the result - when that period has elapsed, all the items in the group will be removed
		/// </summary>
		public string UsagePeriodGroup { get; set;}
		
		
	}
	
	
	
	/// <summary>
	/// Containers are inventory items that can hold other items defined in the catalog, as well as virtual currency, which is added to the player inventory when the container is unlocked, using the UnlockContainerItem API. The items can be anything defined in the catalog, as well as RandomResultTable objects which will be resolved when the container is unlocked. Containers and their keys should be defined as Consumable (having a limited number of uses) in their catalog defintiions, unless the intent is for the player to be able to re-use them infinitely.
	/// </summary>
	public class CatalogItemContainerInfo
	{
		
		
		/// <summary>
		/// ItemId for the catalog item used to unlock the container, if any (if not specified, a call to UnlockContainerItem will open the container, adding the contents to the player inventory and currency balances)
		/// </summary>
		public string KeyItemId { get; set;}
		
		/// <summary>
		/// unique ItemId values for all items which will be added to the player inventory, once the container has been unlocked
		/// </summary>
		[Unordered]
		public List<string> ItemContents { get; set;}
		
		/// <summary>
		/// unique TableId values for all RandomResultTable objects which are part of the container (once unlocked, random tables will be resolved and add the relevant items to the player inventory)
		/// </summary>
		[Unordered]
		public List<string> ResultTableContents { get; set;}
		
		/// <summary>
		/// virtual currency types and balances which will be added to the player inventory when the container is unlocked
		/// </summary>
		public Dictionary<string,uint> VirtualCurrencyContents { get; set;}
		
		
	}
	
	
	
	public class CreateSharedGroupRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group (a random identifier will be assigned, if one is not specified)
		/// </summary>
		public string SharedGroupId { get; set;}
		
		
	}
	
	
	
	public class CreateSharedGroupResult
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		
	}
	
	
	
	public enum Currency
	{
		USD,
		GBP,
		EUR,
		RUB,
		BRL,
		CIS,
		CAD
	}
	
	
	
	public class DeleteSharedGroupRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		
	}
	
	
	
	public class EmptyResult
	{
		
		
		
	}
	
	
	
	public class GetCatalogItemsRequest
	{
		
		
		/// <summary>
		/// which catalog is being requested
		/// </summary>
		public string CatalogVersion { get; set;}
		
		
	}
	
	
	
	public class GetCatalogItemsResult
	{
		
		
		/// <summary>
		/// array of items which can be purchased
		/// </summary>
		[Unordered(SortProperty="ItemId")]
		public List<CatalogItem> Catalog { get; set;}
		
		
	}
	
	
	
	public class GetLeaderboardAroundUserRequest
	{
		
		
		/// <summary>
		/// unique identifier for the title-specific statistic for the leaderboard
		/// </summary>
		public string StatisticName { get; set;}
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		public int MaxResultsCount { get; set;}
		
		
	}
	
	
	
	public class GetLeaderboardAroundUserResult
	{
		
		
		/// <summary>
		/// ordered list of leaderboard entries
		/// </summary>
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		
	}
	
	
	
	public class GetLeaderboardRequest
	{
		
		
		/// <summary>
		/// unique identifier for the title-specific statistic for the leaderboard
		/// </summary>
		public string StatisticName { get; set;}
		
		/// <summary>
		/// first entry in the leaderboard to be retrieved
		/// </summary>
		public int StartPosition { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		public int MaxResultsCount { get; set;}
		
		
	}
	
	
	
	public class GetLeaderboardResult
	{
		
		
		/// <summary>
		/// ordered list of leaderboard entries
		/// </summary>
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		
	}
	
	
	
	public class GetPublisherDataRequest
	{
		
		
		/// <summary>
		///  array of keys to get back data from the Publisher data blob, set by the admin tools
		/// </summary>
		public List<string> Keys { get; set;}
		
		
	}
	
	
	
	public class GetPublisherDataResult
	{
		
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		
	}
	
	
	
	public class GetSharedGroupDataRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// specific keys to retrieve from the shared group (if not specified, all keys will be returned, while an empty array indicates that no keys should be returned)
		/// </summary>
		public List<string> Keys { get; set;}
		
		/// <summary>
		/// if true, return the list of all members of the shared group
		/// </summary>
		public bool? GetMembers { get; set;}
		
		
	}
	
	
	
	public class GetSharedGroupDataResult
	{
		
		
		/// <summary>
		/// data for the requested keys
		/// </summary>
		public Dictionary<string,SharedGroupDataRecord> Data { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers for the members of this group, if requested
		/// </summary>
		public List<string> Members { get; set;}
		
		
	}
	
	
	
	public class GetTitleDataRequest
	{
		
		
		/// <summary>
		///  array of keys to get back data from the TitleData data blob, set by the admin tools
		/// </summary>
		public List<string> Keys { get; set;}
		
		
	}
	
	
	
	public class GetTitleDataResult
	{
		
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		
	}
	
	
	
	public class GetUserAccountInfoRequest
	{
		
		
		public string PlayFabId { get; set;}
		
		
	}
	
	
	
	public class GetUserAccountInfoResult
	{
		
		
		/// <summary>
		/// account info for the user whose information was requested
		/// </summary>
		public UserAccountInfo UserInfo { get; set;}
		
		
	}
	
	
	
	public class GetUserDataRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being requested
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// specific keys to search for in the custom user data
		/// </summary>
		public List<string> Keys { get; set;}
		
		
	}
	
	
	
	public class GetUserDataResult
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being returned
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// user specific data for this title
		/// </summary>
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		
	}
	
	
	
	public class GetUserInventoryRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose inventory is being requested
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// used to limit results to only those from a specific catalog version
		/// </summary>
		public string CatalogVersion { get; set;}
		
		
	}
	
	
	
	public class GetUserInventoryResult
	{
		
		
		/// <summary>
		/// array of inventory items belonging to the user
		/// </summary>
		[Unordered(SortProperty="ItemInstanceId")]
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		
	}
	
	
	
	public class GetUserStatisticsRequest
	{
		
		
		/// <summary>
		/// user for whom statistics are being requested
		/// </summary>
		public string PlayFabId { get; set;}
		
		
	}
	
	
	
	public class GetUserStatisticsResult
	{
		
		
		/// <summary>
		/// user statistics for the requested user
		/// </summary>
		public Dictionary<string,int> UserStatistics { get; set;}
		
		
	}
	
	
	
	public class GrantItemsToUserRequest
	{
		
		
		/// <summary>
		/// catalog version from which items are to be granted
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier of the user to whom the catalog items are to be granted
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// string detailing any additional information concerning this operation
		/// </summary>
		public string Annotation { get; set;}
		
		/// <summary>
		/// array of itemIds to grant to the user
		/// </summary>
		public List<string> ItemIds { get; set;}
		
		
	}
	
	
	
	public class GrantItemsToUserResult
	{
		
		
		/// <summary>
		/// array of items granted to users
		/// </summary>
		public List<ItemGrantResult> ItemGrantResults { get; set;}
		
		
	}
	
	
	
	public class GrantItemsToUsersRequest
	{
		
		
		/// <summary>
		/// catalog version from which items are to be granted
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// array of items to grant and the users to whom the items are to be granted
		/// </summary>
		[Unordered]
		public List<ItemGrant> ItemGrants { get; set;}
		
		
	}
	
	
	
	public class GrantItemsToUsersResult
	{
		
		
		/// <summary>
		/// array of items granted to users
		/// </summary>
		public List<ItemGrantResult> ItemGrantResults { get; set;}
		
		
	}
	
	
	
	public class ItemGrant
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user to whom the catalog item is to be granted
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique identifier of the catalog item to be granted to the user
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// string detailing any additional information concerning this operation
		/// </summary>
		public string Annotation { get; set;}
		
		
	}
	
	
	
	/// <summary>
	/// Result of granting an item to a user
	/// </summary>
	public class ItemGrantResult : IComparable<ItemGrantResult>
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user to whom the catalog item is to be granted
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique identifier of the catalog item to be granted to the user
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique instance Id of the granted item
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// string detailing any additional information concerning this operation
		/// </summary>
		public string Annotation { get; set;}
		
		/// <summary>
		/// result of this operation
		/// </summary>
		public bool Result { get; set;}
		
		
		public int CompareTo(ItemGrantResult other)
        {
            if (other == null || other.ItemInstanceId == null) return 1;
            if (ItemInstanceId == null) return -1;
            return ItemInstanceId.CompareTo(other.ItemInstanceId);
        }
		
	}
	
	
	
	/// <summary>
	/// A unique instance of an item in a user's inventory
	/// </summary>
	public class ItemInstance : IComparable<ItemInstance>
	{
		
		
		/// <summary>
		/// unique identifier for the inventory item, as defined in the catalog
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique item identifier for this specific instance of the item
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// class name for the inventory item, as defined in the catalog
		/// </summary>
		public string ItemClass { get; set;}
		
		/// <summary>
		/// timestamp for when this instance was purchased
		/// </summary>
		public DateTime? PurchaseDate { get; set;}
		
		/// <summary>
		/// timestamp for when this instance will expire
		/// </summary>
		public DateTime? Expiration { get; set;}
		
		/// <summary>
		/// total number of remaining uses, if this is a consumable item
		/// </summary>
		public int? RemainingUses { get; set;}
		
		/// <summary>
		/// game specific comment associated with this instance when it was added to the user inventory
		/// </summary>
		public string Annotation { get; set;}
		
		/// <summary>
		/// catalog version for the inventory item, when this instance was created
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container
		/// </summary>
		public string BundleParent { get; set;}
		
		
		public int CompareTo(ItemInstance other)
        {
            if (other == null || other.ItemInstanceId == null) return 1;
            if (ItemInstanceId == null) return -1;
            return ItemInstanceId.CompareTo(other.ItemInstanceId);
        }
		
	}
	
	
	
	public class ModifyItemUsesRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose item is being modified
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique instance identifier of the item to be modified
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// number of uses to add to the item. Can be negative to remove uses.
		/// </summary>
		public int UsesToAdd { get; set;}
		
		
	}
	
	
	
	public class ModifyItemUsesResult
	{
		
		
		/// <summary>
		/// unique instance identifier of the item with uses consumed
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// number of uses remaining on the item
		/// </summary>
		public int RemainingUses { get; set;}
		
		
	}
	
	
	
	public class ModifyUserVirtualCurrencyResult
	{
		
		
		/// <summary>
		/// name of the virtual currency which was modified
		/// </summary>
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// balance of the virtual currency after modification
		/// </summary>
		public int Balance { get; set;}
		
		
	}
	
	
	
	public class NotifyMatchmakerPlayerLeftRequest
	{
		
		
		/// <summary>
		/// unique identifier of the Game Instance the user is leaving
		/// </summary>
		public string LobbyId { get; set;}
		
		public string PlayFabId { get; set;}
		
		
	}
	
	
	
	public class NotifyMatchmakerPlayerLeftResult
	{
		
		
		/// <summary>
		/// state of user leaving the Game Server Instance
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public PlayerConnectionState? PlayerState { get; set;}
		
		
	}
	
	
	
	public enum PlayerConnectionState
	{
		Unassigned,
		Connecting,
		Participating,
		Participated,
		Reconnecting
	}
	
	
	
	public class PlayerLeaderboardEntry
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user for this leaderboard entry
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// title-specific display name of the user for this leaderboard entry
		/// </summary>
		public string DisplayName { get; set;}
		
		/// <summary>
		/// specific value of the user's statistic
		/// </summary>
		public int StatValue { get; set;}
		
		/// <summary>
		/// user's overall position in the leaderboard
		/// </summary>
		public int Position { get; set;}
		
		
	}
	
	
	
	public class RedeemMatchmakerTicketRequest
	{
		
		
		/// <summary>
		/// server authorization ticket passed back from a call to Matchmake or StartGame
		/// </summary>
		public string Ticket { get; set;}
		
		/// <summary>
		/// unique identifier of the Game Server Instance that is asking for validation of the authorization ticket
		/// </summary>
		public string LobbyId { get; set;}
		
		
	}
	
	
	
	public class RedeemMatchmakerTicketResult
	{
		
		
		/// <summary>
		/// boolean indicating whether the ticket was validated by the PlayFab service
		/// </summary>
		public bool TicketIsValid { get; set;}
		
		/// <summary>
		/// error value if the ticket was not validated
		/// </summary>
		public string Error { get; set;}
		
		/// <summary>
		/// user account information for the user validated
		/// </summary>
		public UserAccountInfo UserInfo { get; set;}
		
		
	}
	
	
	
	public class RemoveSharedGroupMembersRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers of users to remove from the shared group
		/// </summary>
		public List<string> PlayFabIds { get; set;}
		
		
	}
	
	
	
	public class RemoveSharedGroupMembersResult
	{
		
		
		
	}
	
	
	
	public class ReportPlayerServerRequest
	{
		
		
		/// <summary>
		/// PlayFabId of the reporting player
		/// </summary>
		public string ReporterId { get; set;}
		
		/// <summary>
		/// PlayFabId of the reported player
		/// </summary>
		public string ReporteeId { get; set;}
		
		/// <summary>
		/// title player was reported in, optional if report not for specific title
		/// </summary>
		public string TitleId { get; set;}
		
		/// <summary>
		/// Optional additional comment by reporting player
		/// </summary>
		public string Comment { get; set;}
		
		
	}
	
	
	
	public class ReportPlayerServerResult
	{
		
		
		public bool Updated { get; set;}
		
		public int SubmissionsRemaining { get; set;}
		
		
	}
	
	
	
	public class SendPushNotificationRequest
	{
		
		
		/// <summary>
		/// PlayFabId of the recipient of the push notification
		/// </summary>
		public string Recipient { get; set;}
		
		/// <summary>
		/// text of message to send
		/// </summary>
		public string Message { get; set;}
		
		/// <summary>
		/// subject of message to send (may not be displayed in all platforms
		/// </summary>
		public string Subject { get; set;}
		
		
	}
	
	
	
	public class SendPushNotificationResult
	{
		
		
		
	}
	
	
	
	public class SetPublisherDataRequest
	{
		
		
		/// <summary>
		/// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
		/// </summary>
		public string Key { get; set;}
		
		/// <summary>
		/// new value to set. Set to null to remove a value
		/// </summary>
		public string Value { get; set;}
		
		
	}
	
	
	
	public class SetPublisherDataResult
	{
		
		
		
	}
	
	
	
	public class SetTitleDataRequest
	{
		
		
		/// <summary>
		/// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
		/// </summary>
		public string Key { get; set;}
		
		/// <summary>
		/// new value to set. Set to null to remove a value
		/// </summary>
		public string Value { get; set;}
		
		
	}
	
	
	
	public class SetTitleDataResult
	{
		
		
		
	}
	
	
	
	public class SharedGroupDataRecord
	{
		
		
		/// <summary>
		/// data stored for the specified group data key
		/// </summary>
		public string Value { get; set;}
		
		/// <summary>
		/// PlayFabId of the user to last update this value
		/// </summary>
		public string LastUpdatedBy { get; set;}
		
		/// <summary>
		/// timestamp for when this data was last updated
		/// </summary>
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// indicates whether this data can be read by all users (public) or only members of the group (private)
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserDataPermission? Permission { get; set;}
		
		
	}
	
	
	
	public class SubtractUserVirtualCurrencyRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose virtual currency balance is to be decremented
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// name of the virtual currency which is to be decremented
		/// </summary>
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be subtracted from the user balance of the specified virtual currency
		/// </summary>
		public int Amount { get; set;}
		
		
	}
	
	
	
	public enum TitleActivationStatus
	{
		None,
		ActivatedTitleKey,
		PendingSteam,
		ActivatedSteam,
		RevokedSteam
	}
	
	
	
	public class UpdateSharedGroupDataRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// key value pairs to be stored in the shared group - note that keys will be trimmed of whitespace, must not begin with a '!' character, and that null values will result in the removal of the key from the data set
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// permission to be applied to all user data keys in this request
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserDataPermission? Permission { get; set;}
		
		
	}
	
	
	
	public class UpdateSharedGroupDataResult
	{
		
		
		
	}
	
	
	
	public class UpdateUserDataRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being updated
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// data to be written to the user's custom data. Keys are trimmed of whitespace. Keys may not begin with a '!' character.
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserDataPermission? Permission { get; set;}
		
		
	}
	
	
	
	public class UpdateUserDataResult
	{
		
		
		
	}
	
	
	
	public class UpdateUserInternalDataRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being updated
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// data to be written to the user's custom data
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		
	}
	
	
	
	public class UpdateUserStatisticsRequest
	{
		
		
		/// <summary>
		/// user whose statistics are to be updated
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// statistics to be updated with the provided values
		/// </summary>
		public Dictionary<string,int> UserStatistics { get; set;}
		
		
	}
	
	
	
	public class UpdateUserStatisticsResult
	{
		
		
		
	}
	
	
	
	public class UserAccountInfo
	{
		
		
		/// <summary>
		/// unique identifier for the user account
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user account was created
		/// </summary>
		public DateTime Created { get; set;}
		
		/// <summary>
		/// user account name in the PlayFab service
		/// </summary>
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific information for the user account
		/// </summary>
		public UserTitleInfo TitleInfo { get; set;}
		
		/// <summary>
		/// personal information for the user which is considered more sensitive
		/// </summary>
		public UserPrivateAccountInfo PrivateInfo { get; set;}
		
		/// <summary>
		/// user Facebook information, if a Facebook account has been linked
		/// </summary>
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// user Steam information, if a Steam account has been linked
		/// </summary>
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// user Gamecenter information, if a Gamecenter account has been linked
		/// </summary>
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		
	}
	
	
	
	public enum UserDataPermission
	{
		Private,
		Public
	}
	
	
	
	public class UserDataRecord
	{
		
		
		/// <summary>
		/// user-supplied data for this user data key
		/// </summary>
		public string Value { get; set;}
		
		/// <summary>
		/// timestamp indicating when this data was last updated
		/// </summary>
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// Permissions on this data key
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserDataPermission? Permission { get; set;}
		
		
	}
	
	
	
	public class UserFacebookInfo
	{
		
		
		/// <summary>
		/// Facebook identifier
		/// </summary>
		public string FacebookId { get; set;}
		
		
	}
	
	
	
	public class UserGameCenterInfo
	{
		
		
		/// <summary>
		/// Gamecenter identifier
		/// </summary>
		public string GameCenterId { get; set;}
		
		
	}
	
	
	
	public enum UserOrigination
	{
		Organic,
		Steam,
		Google,
		Amazon,
		Facebook,
		Kongregate,
		GamersFirst,
		Unknown,
		IOS,
		LoadTest,
		Android,
		PSN,
		GameCenter
	}
	
	
	
	public class UserPrivateAccountInfo
	{
		
		
		/// <summary>
		/// user email address
		/// </summary>
		public string Email { get; set;}
		
		
	}
	
	
	
	public class UserSteamInfo
	{
		
		
		/// <summary>
		/// Steam identifier
		/// </summary>
		public string SteamId { get; set;}
		
		/// <summary>
		/// the country in which the player resides, from Steam data
		/// </summary>
		public string SteamCountry { get; set;}
		
		/// <summary>
		/// currency type set in the user Steam account
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Currency? SteamCurrency { get; set;}
		
		/// <summary>
		/// what stage of game ownership the user is listed as being in, from Steam
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public TitleActivationStatus? SteamActivationStatus { get; set;}
		
		
	}
	
	
	
	public class UserTitleInfo
	{
		
		
		/// <summary>
		/// name of the user, as it is displayed in-game
		/// </summary>
		public string DisplayName { get; set;}
		
		/// <summary>
		/// source by which the user first joined the game, if known
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserOrigination? Origination { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user was first associated with this game (this can differ significantly from when the user first registered with PlayFab)
		/// </summary>
		public DateTime Created { get; set;}
		
		/// <summary>
		/// timestamp for the last user login for this title
		/// </summary>
		public DateTime? LastLogin { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user first signed into this game (this can differ from the Created timestamp, as other events, such as issuing a beta key to the user, can associate the title to the user)
		/// </summary>
		public DateTime? FirstLogin { get; set;}
		
		/// <summary>
		/// boolean indicating whether or not the user is currently banned for a title
		/// </summary>
		public bool? isBanned { get; set;}
		
		
	}
	
}
