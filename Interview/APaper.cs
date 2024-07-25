using System;
namespace Interview
{
    public static class APaper
    {
        public static bool CanBuild(int[] A)
        {
            if (A.Length == 0)
            {
                return false;
            }

            double pageSizeComparedToA0 = 1;
            double target = 1;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] * pageSizeComparedToA0 >= target)
                {
                    return true;
                }

                target -= A[i] * pageSizeComparedToA0;
                pageSizeComparedToA0 /= 2;
            }

            return false;
        }
    }
}
