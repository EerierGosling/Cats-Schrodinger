using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timeline {
    public class Reality {
        public string id;
        public string[] paths;

        public Reality(string id, string[] paths) {
            this.id = id;
            this.paths = paths;
        }
    }

    public static class Realities
    {
        public static Dictionary<string, Reality> realities = new Dictionary<string, Reality>() {
            { "root", new Reality("root", new string[] {"radiationDeath", "survival"}) },
            { "radiationDeath", new Reality("radiationDeath", new string[] {"root"}) },
            { "survival", new Reality("survival", new string[] {"root"}) },
        };
    }
}