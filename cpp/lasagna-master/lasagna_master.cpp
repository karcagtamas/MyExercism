#include "lasagna_master.h"

namespace lasagna_master
{

    int preparationTime(const std::vector<std::string> &layers, int avg)
    {
        return layers.size() * avg;
    }

    amount quantities(const std::vector<std::string> &layers)
    {
        int noodle_count = 0;
        int sauce_count = 0;

        for (const std::string &layer : layers)
        {
            if (layer == "noodles")
            {
                ++noodle_count;
            }
            else if (layer == "sauce")
            {
                ++sauce_count;
            }
        }

        amount result;
        result.noodles = noodle_count * 50;
        result.sauce = sauce_count * 0.2;

        return result;
    }

    void addSecretIngredient(std::vector<std::string> &mine, const std::vector<std::string> &friends)
    {
        addSecretIngredient(mine, friends.back());
    }

    void addSecretIngredient(std::vector<std::string> &mine, const std::string &secretIngredient)
    {
        mine.back() = secretIngredient;
    }

    std::vector<double> scaleRecipe(const std::vector<double> &quantities, int portions)
    {
        double factor = portions / 2.0;

        std::vector<double> result;
        result.reserve(quantities.size());

        for (double q : quantities)
        {
            result.push_back(q * factor);
        }

        return result;
    }

} // namespace lasagna_master
