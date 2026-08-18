import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class Ledger {
    public LedgerEntry createLedgerEntry(String d, String desc, int c) {
        return new LedgerEntry(LocalDate.parse(d), desc, c);
    }

    public String format(String cur, String loc, LedgerEntry[] entries) {
        String header = "Date       | Description               | Change       ";
        String curSymb = "$";
        String datPat = "MM/dd/yyyy";
        String decSep = ".";
        String thSep = ",";

        if (!cur.equals("USD") && !cur.equals("EUR")) {
            throw new IllegalArgumentException("Invalid locale");
        }

        if (!loc.equals("en-US") && !loc.equals("nl-NL")) {
            throw new IllegalArgumentException("Invalid locale");
        }

        if (cur.equals("EUR")) {
            curSymb = "€";
        }

        if (loc.equals("nl-NL")) {
            datPat = "dd/MM/yyyy";
            decSep = ",";
            thSep = ".";
            header = "Datum      | Omschrijving              | Verandering  ";
        }

        final var sb = new StringBuilder(header);

        if (entries.length > 0) {
            List<LedgerEntry> neg = new ArrayList<>();
            List<LedgerEntry> pos = new ArrayList<>();
            for (LedgerEntry e : entries) {
                if (e.getChange() >= 0) {
                    pos.add(e);
                } else {
                    neg.add(e);
                }
            }

            neg.sort(Comparator.comparing(LedgerEntry::getLocalDate));
            pos.sort(Comparator.comparing(LedgerEntry::getLocalDate));

            List<LedgerEntry> all = new ArrayList<>();
            all.addAll(neg);
            all.addAll(pos);

            for (LedgerEntry e : all) {
                String date = e.getLocalDate().format(DateTimeFormatter.ofPattern(datPat));

                String desc = e.getDescription();
                if (desc.length() > 25) {
                    desc = desc.substring(0, 22);
                    desc = desc + "...";
                }

                String converted = e.getChange() < 0
                        ? String.format("%.02f", (e.getChange() / 100) * -1)
                        : String.format("%.02f", e.getChange() / 100);

                String[] parts = converted.split("\\.");
                String amount = "";
                int count = 1;
                for (int ind = parts[0].length() - 1; ind >= 0; ind--) {
                    if (((count % 3) == 0) && ind > 0) {
                        amount = thSep + parts[0].charAt(ind) + amount;
                    } else {
                        amount = parts[0].charAt(ind) + amount;
                    }
                    count++;
                }

                amount = loc.equals("nl-NL")
                        ? curSymb + " " + amount + decSep + parts[1]
                        : curSymb + amount + decSep + parts[1];

                if (e.getChange() < 0) {
                    amount = loc.equals("en-US")
                            ? "(" + amount + ")"
                            : curSymb + " -" + amount.replace(curSymb, "").trim() + " ";
                } else {
                    amount = loc.equals("nl-NL")
                            ? " " + amount + " "
                            : amount + " ";
                }

                sb.append("\n");
                sb.append("%s | %-25s | %13s".formatted(date, desc, amount));
            }

        }

        return sb.toString();
    }

    public static class LedgerEntry {
        LocalDate localDate;
        String description;
        double change;

        public LedgerEntry(LocalDate localDate, String description, double change) {
            this.localDate = localDate;
            this.description = description;
            this.change = change;
        }

        public LocalDate getLocalDate() {
            return localDate;
        }

        public void setLocalDate(LocalDate localDate) {
            this.localDate = localDate;
        }

        public String getDescription() {
            return description;
        }

        public void setDescription(String description) {
            this.description = description;
        }

        public double getChange() {
            return change;
        }

        public void setChange(double change) {
            this.change = change;
        }
    }

}
