#include "eliuds_eggs.h"

namespace chicken_coop
{

    unsigned int positions_to_quantity(unsigned int cnt)
    {
        unsigned int c = 0;

        while (cnt > 0)
        {
            c += cnt & 1;
            cnt >>= 1;
        }

        return c;
    }

} // namespace chicken_coop
