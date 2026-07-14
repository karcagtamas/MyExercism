import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class MicroBlogTest {

    private final MicroBlog microBlog = new MicroBlog();

    @Test
    @DisplayName("English language short")
    public void englishLanguageShort() {
        String expected = "Hi";
        assertThat(microBlog.truncate("Hi")).isEqualTo(expected);
    }

    @Test
    @DisplayName("English language long")
    public void englishLanguageLong() {
        String expected = "Hello";
        assertThat(microBlog.truncate("Hello there")).isEqualTo(expected);
    }

    @Test
    @DisplayName("German language short (broth)")
    public void germanLanguageShortBroth() {
        String expected = "brühe";
        assertThat(microBlog.truncate("brühe")).isEqualTo(expected);
    }

    @Test
    @DisplayName("German language long (bear carpet → beards)")
    public void germanLanguageLongBearCarpetToBeards() {
        String expected = "Bärte";
        assertThat(microBlog.truncate("Bärteppich")).isEqualTo(expected);
    }

    @Test
    @DisplayName("Bulgarian language short (good)")
    public void bulgarianLanguageShortGood() {
        String expected = "Добър";
        assertThat(microBlog.truncate("Добър")).isEqualTo(expected);
    }

    @Test
    @DisplayName("Greek language short (health)")
    public void greekLanguageShortHealth() {
        String expected = "υγειά";
        assertThat(microBlog.truncate("υγειά")).isEqualTo(expected);
    }

    @Test
    @DisplayName("Maths short")
    public void mathsShort() {
        String expected = "a=πr²";
        assertThat(microBlog.truncate("a=πr²")).isEqualTo(expected);
    }

    @Test
    @DisplayName("Maths long")
    public void mathsLong() {
        String expected = "∅⊊ℕ⊊ℤ";
        assertThat(microBlog.truncate("∅⊊ℕ⊊ℤ⊊ℚ⊊ℝ⊊ℂ")).isEqualTo(expected);
    }

    @Test
    @DisplayName("English and emoji short")
    public void englishAndEmojiShort() {
        String expected = "Fly 🛫";
        assertThat(microBlog.truncate("Fly 🛫")).isEqualTo(expected);
    }

    @Test
    @DisplayName("Emoji short")
    public void emojiShort() {
        String expected = "💇";
        assertThat(microBlog.truncate("💇")).isEqualTo(expected);
    }

    @Test
    @DisplayName("Emoji long")
    public void emojiLong() {
        String expected = "❄🌡🤧🤒🏥";
        assertThat(microBlog.truncate("❄🌡🤧🤒🏥🕰😀")).isEqualTo(expected);
    }

    @Test
    @DisplayName("Royal Flush?")
    public void royalFlush() {
        String expected = "🃎🂸🃅🃋🃍";
        assertThat(microBlog.truncate("🃎🂸🃅🃋🃍🃁🃊")).isEqualTo(expected);
    }
}
