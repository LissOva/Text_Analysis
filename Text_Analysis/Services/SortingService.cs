namespace Text_Analysis.Services
{
    public class SortingService
    {
        //Встроенна сортировка
        //Используются средства C# для сортировки
        public static List<KeyValuePair<string, int>> BuiltInSort(Dictionary<string, int> dictionary)
        {
            return dictionary.OrderByDescending(pair => pair.Value).ToList();
        }

        //Сортировка пузырьком
        public static List<KeyValuePair<string, int>> BubbleSort(Dictionary<string, int> dictionary)
        {
            var items = dictionary.ToArray();
            int n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j].Value < items[j + 1].Value)
                    {
                        var temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }

            return [.. items];
        }

        //Сортировка слиянием
        public static List<KeyValuePair<string, int>> MergeSort(Dictionary<string, int> dictionary)
        {
            var items = dictionary.ToArray();

            MergeSortRecursive(items, 0, items.Length - 1);

            return [.. items];
        }

        // Рекурсивная сортировка слиянием
        static void MergeSortRecursive(KeyValuePair<string, int>[] array, int left, int right)
        {
            if (left >= right)
                return;

            int mid = left + (right - left) / 2;

            MergeSortRecursive(array, left, mid);
            MergeSortRecursive(array, mid + 1, right);

            Merge(array, left, mid, right);
        }

        // Слияние двух отсортированных частей
        static void Merge(KeyValuePair<string, int>[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            var leftArray = new KeyValuePair<string, int>[n1];
            var rightArray = new KeyValuePair<string, int>[n2];

            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i].Value >= rightArray[j].Value)
                    array[k++] = leftArray[i++];
                else
                    array[k++] = rightArray[j++];
            }

            while (i < n1)
                array[k++] = leftArray[i++];

            while (j < n2)
                array[k++] = rightArray[j++];
        }

        //Сортировка Шелла
        public static List<KeyValuePair<string, int>> ShellSort(Dictionary<string, int> dictionary)
        {
            var items = dictionary.ToArray();
            int n = items.Length;

            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    var temp = items[i];
                    int j = i;

                    while (j >= gap && items[j - gap].Value < temp.Value)
                    {
                        items[j] = items[j - gap];
                        j -= gap;
                    }
                    items[j] = temp;
                }

                gap /= 2;
            }

            return [.. items];
        }
    }
}
