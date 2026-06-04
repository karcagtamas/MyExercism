#include "darts.h"
#include "math.h"

namespace darts
{

    int score(float x, float y)
    {
        auto fromO = sqrt(pow(x, 2) + pow(y, 2));

        if (fromO > 10)
        {
            return 0;
        }

        if (fromO > 5)
        {
            return 1;
        }

        if (fromO > 1)
        {
            return 5;
        }

        return 10;
    }

} // namespace darts
