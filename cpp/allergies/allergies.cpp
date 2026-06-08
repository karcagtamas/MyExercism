#include "allergies.h"

namespace allergies
{

    bool allergy_test::is_allergic_to(const std::string &allergen) const
    {
        if (allergen == "eggs")
            return score_ & 1;
        if (allergen == "peanuts")
            return score_ & 2;
        if (allergen == "shellfish")
            return score_ & 4;
        if (allergen == "strawberries")
            return score_ & 8;
        if (allergen == "tomatoes")
            return score_ & 16;
        if (allergen == "chocolate")
            return score_ & 32;
        if (allergen == "pollen")
            return score_ & 64;
        if (allergen == "cats")
            return score_ & 128;

        return false;
    }

    std::unordered_set<std::string> allergy_test::get_allergies() const
    {
        std::unordered_set<std::string> allergies;

        if (score_ & 1)
            allergies.emplace("eggs");
        if (score_ & 2)
            allergies.emplace("peanuts");
        if (score_ & 4)
            allergies.emplace("shellfish");
        if (score_ & 8)
            allergies.emplace("strawberries");
        if (score_ & 16)
            allergies.emplace("tomatoes");
        if (score_ & 32)
            allergies.emplace("chocolate");
        if (score_ & 64)
            allergies.emplace("pollen");
        if (score_ & 128)
            allergies.emplace("cats");

        return allergies;
    }

} // namespace allergies
