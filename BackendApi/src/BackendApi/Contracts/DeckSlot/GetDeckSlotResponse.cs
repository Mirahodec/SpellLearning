namespace BackendApi.Contracts.DeckSlot
{
    public class GetDeckSlotResponse
    {
        public int SlotId { get; set; }
        public int DeckId { get; set; }
        public int InventoryId { get; set; }
        public int SlotNumber { get; set; }
    }
}