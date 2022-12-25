// Bubble Sort

static int[] BubbleSort(int[] array){
  int temp;

  for (int j = 0; j < array.Length - 1; j++){
    for (int i = 0; i < array.Length - j - 1; i++){
      if (array[i] > array[i+1]){
        temp = array[i+1];
        array[i+1] = array[i];
        array[i] = temp;
      }
    }
  }

  return array;
}


int[] test = {0,1,2,3,4,2,3,7,8,7,3,9};

int[] sortedArray = BubbleSort(test);

for (int i = 0; i < sortedArray.Length; i++ ){
  Console.Write(sortedArray[i] + " ");  
}

