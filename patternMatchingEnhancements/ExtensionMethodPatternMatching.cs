namespace CS9;

public static class ExtensionMethodPatternMatching {
    public static bool IsLetter(this char c) =>
        c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';
    
    public static bool IsNotNull(this List<String> o) =>
        o is not null;
}
