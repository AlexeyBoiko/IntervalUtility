# IntervalUtility
.Net C # utility for working with intervals, such as time periods. The utility allows you to find intersections of periods, exclude periods, etc.

[NuGet](https://www.nuget.org/packages/IntervalUtility/ "Interval Utility NuGet")

[Interactive demo](https://alexeyboiko.github.io/IntervalUtility/ "Interval Utility Demo")


## Examples
For simplicity, the examples use integer ranges. However, the utility supports not only integers, you can use the utility to work with time periods or decimal, or float, etc.

### Equals of intervals

```cs
var intervalA = new Interval<int>(3, 6);
var intervalB = new Interval<int>(4, 8);

var isEquals = intervalA == intervalB;
// => false


               3              6
               |--------------|
                    4                   8
                    |-------------------|
```

```cs
var intervalA = new Interval<int>(null, 4);
var intervalB = new Interval<int>(null, 4);

var isEquals = intervalA == intervalB;
// => true


                    4
--------------------|
                    4
--------------------|
```

## Whether the value is included in an interval (by default, ends are not included) - InRange
```cs
var interval = new Interval<int>(3, 6);

var intervalUtil = new IntervalUtil();
var isInRange = intervalUtil.InRange(interval, 4);
// => true


               3              6
               |--------------|
                    4
                    |

```

```cs
var interval = new Interval<int>(null, 6);

var intervalUtil = new IntervalUtil();
var isInRange = intervalUtil.InRange(interval, 6, includeEnds:true);
// => true


                              6
------------------------------|
                              6
                              |
```

## Exclude from intervalA intervalb - Exclude
```cs
var intervalA = new Interval<int>(3, 6);
var intervalB = new Interval<int>(1, 4);

var intervalUtil = new IntervalUtil();
var res = intervalUtil.Exclude(intervalA, intervalB);
// => [4,6]


               3              6
               |--------------|
     1              4
     |--------------|
Result
                    4         6
                    |---------|
```

```cs
var intervalA = new Interval<int>(3, null);
var intervalB = new Interval<int>(4, 5);

var intervalUtil = new IntervalUtil();
var res = intervalUtil.Exclude(intervalA, intervalB)
// => [3,4], [5,null]


               3
               |----------------------------------
                    4    5
                    |----|
Result
               3    4    5
               |----|    |------------------------
```

## Exclude from array intervalsA array intervalsB - Exclude

```cs
var intervalsA = new[] { new Interval<int>(1, 5), new Interval<int>(7, 10) };
var intervalsB =
    new[] { new Interval<int>(0, 2), new Interval<int>(3, 5), new Interval<int>(8, 9) };

var intervalUtil = new IntervalUtil();
var res = intervalUtil.Exclude(intervalsA, intervalsB);
// => [2,3], [7,8], [9,10]


     1                   5         7              10
     |-------------------|         |--------------|
0         2    3         5              8    9
|---------|    |---------|              |----|
Result
          2    3                   7    8    9    10
          |----|                   |----|    |----|
```

## Find intersections - Intersection
```cs
var intervalA = new Interval<int>(0, 3);
var intervalB = new Interval<int>(2, 4);
            
var intervalUtil = new IntervalUtil();
var res = intervalUtil.Intersection(intervalA, intervalB);
// => [2,3]


0              3
|--------------|
          2         4
          |---------|
Result
          2    3
          |----|
```

## Find intersections of arrays of intervals - Intersections

```cs
var arrayOfArrays = new[] {
    new[] { new Interval<int>(2,5), new Interval<int>(7, 9) },
    new[] { new Interval<int>(0,3), new Interval<int>(4, 6), new Interval<int>(7, 10) },
    new[] { new Interval<int>(1,4), new Interval<int>(5, 8) },
};

var intervalUtil = new IntervalUtil();
var res = intervalUtil.Intersections(arrayOfArrays);
// => [2,3], [7,8]


          2              5         7         9                                                      
          |--------------|         |---------|                                                      
0              3    4         6    7              10                                                
|--------------|    |---------|    |--------------|                                                 
     1              4    5              8                                                           
     |--------------|    |--------------|                                                           
Result
          2    3                   7    8                                                           
          |----|                   |----|   
```
