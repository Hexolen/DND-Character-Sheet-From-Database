namespace CharacterSheetAPI
{
    public class Character
    {
        public int Id { get; set; }
        public string Character_Name { get; set; } = String.Empty;
        public string Player_Name { get; set; } = String.Empty;
        public string Character_Class { get; set; } = String.Empty;
        public string Character_Race { get; set; } = String.Empty;
        public string Character_Background { get; set; } = String.Empty;
        public int Level { get; set; } = 0;
         
    }
}
