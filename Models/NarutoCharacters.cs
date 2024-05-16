using Newtonsoft.Json;

namespace PROJECTE_DAW_API.Models.Naruto
{
    public class Age
    {
        [JsonProperty("Part II")]
        public string PartII { get; set; }

        [JsonProperty("Part I")]
        public string PartI { get; set; }

        [JsonProperty("Academy Graduate")]
        public string AcademyGraduate { get; set; }

        [JsonProperty("Chunin Promotion")]
        public string ChuninPromotion { get; set; }

        [JsonProperty("Boruto Manga")]
        public string BorutoManga { get; set; }
    }

    public class NarutoCharacter
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<string> images { get; set; }
        public Debut debut { get; set; }
        public List<string> jutsu { get; set; }
        public Personal personal { get; set; }
        public List<string> uniqueTraits { get; set; }
        public Family family { get; set; }
        public List<string> natureType { get; set; }
        public Rank rank { get; set; }
        public VoiceActors voiceActors { get; set; }
        public List<string> tools { get; set; }
    }

    public class Debut
    {
        public string novel { get; set; }
        public string movie { get; set; }
        public string appearsIn { get; set; }
        public string manga { get; set; }
        public string anime { get; set; }
        public string game { get; set; }
        public string ova { get; set; }
    }

    public class Family
    {
        [JsonProperty("incarnation with the god tree")]
        public string incarnationwiththegodtree { get; set; }

        [JsonProperty("depowered form")]
        public string depoweredform { get; set; }
        public string son { get; set; }
        public string nephew { get; set; }

        [JsonProperty("adoptive son")]
        public string adoptiveson { get; set; }
        public string father { get; set; }

        [JsonProperty("adoptive brother")]
        public string adoptivebrother { get; set; }
        public string cousin { get; set; }

        [JsonProperty("adoptive father")]
        public string adoptivefather { get; set; }
        public string brother { get; set; }
        public string husband { get; set; }
    }

    public class Height
    {
        [JsonProperty("Part II")]
        public string PartII { get; set; }

        [JsonProperty("Part I")]
        public string PartI { get; set; }

        [JsonProperty("Blank Period")]
        public string BlankPeriod { get; set; }
        public string Gaiden { get; set; }
    }

    public class NinjaRank
    {
        [JsonProperty("Part II")]
        public string PartII { get; set; }

        [JsonProperty("Part I")]
        public string PartI { get; set; }

        [JsonProperty("Boruto Manga")]
        public string BorutoManga { get; set; }
    }

    public class Personal
    {
        public string species { get; set; }
        public string status { get; set; }
        public string kekkeiGenkai { get; set; }
        public string classification { get; set; }
        public List<string> jinchriki { get; set; }
        public List<string> titles { get; set; }
        public object affiliation { get; set; }
        public string birthdate { get; set; }
        public string sex { get; set; }
        public Height height { get; set; }
        public Weight weight { get; set; }
        public string bloodType { get; set; }
        public object occupation { get; set; }
        public object team { get; set; }
        public string partner { get; set; }
        public Age age { get; set; }
        public string clan { get; set; }
    }

    public class Rank
    {
        public NinjaRank ninjaRank { get; set; }
        public string ninjaRegistration { get; set; }
    }

    public class Root
    {
        public List<NarutoCharacter> characters { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalCharacters { get; set; }
    }

    public class VoiceActors
    {
        public object japanese { get; set; }
        public object english { get; set; }
    }

    public class Weight
    {
        [JsonProperty("Part II")]
        public string PartII { get; set; }

        [JsonProperty("Part I")]
        public string PartI { get; set; }
    }
}

