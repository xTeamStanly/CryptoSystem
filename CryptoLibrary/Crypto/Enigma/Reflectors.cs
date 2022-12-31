namespace Library.Crypto.Enigma {
    public static class Reflectors {
        // https://en.wikipedia.org/wiki/Enigma_rotor_details

        public enum ReflectorType {
            A = 0,
            B = 1,
            C = 2
        };

        public static Reflector[] reflectors = new Reflector[] {
            new Reflector("Reflector A", "EJMZALYXVBWFCRQUONTSPIKHGD", ReflectorType.A),
            new Reflector("Reflector B", "YRUHQSLDPXNGOKMIEBFZCWVJAT", ReflectorType.B),
            new Reflector("Reflector C", "FVPJIAOYEDRZXWGCTKUQSBNMHL", ReflectorType.C)
        };
    }
}
