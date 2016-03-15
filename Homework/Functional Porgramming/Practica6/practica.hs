-- TPP Lab Lessons translated to Haskell
-- Author: Esteban Montes

module Sesion5
(
 asinH,
 acosH,
 atanH,
 isEven,
 countEvens,
 isPrime,
 getPrimes,
 composeG

) where

import Data.Char
-- Exercise 1
asinH :: Double -> Double
asinH x = log(x+sqrt((x*x)+1))

acosH :: Double -> Double
acosH x = log(x+sqrt((x*x)-1))

atanH :: Double -> Double
atanH x = (log(1+x)-log(1-x))/2


-- Or as lambdas, as you pref
lambdaAsinh :: Double
lambdaAsinh = \x -> log(x+sqrt((x*x)+1))

lambdaAcosh :: Double
lambdaAcosh = \x -> log(x+sqrt((x*x)-1))

lambdaAtanh :: Double
lambdaAtanh = \x -> (log(1+x)-log(1-x))/2


-- Exercise 2
isEven :: Int -> Bool
isEven x = (x `mod` 2)== 0

countEvens :: [Int] -> Int
countEvens x = length [i | i <- x, isEven i]


-- Exercise 3
isPrime :: Int -> Bool
isPrime k
        | k <= 1 = False
        | otherwise = not $ elem 0 (map (mod k)[2..k-1])

getPrimes :: Int -> [Int]
getPrimes n = [x | x <- [0 .. n], isPrime x]


-- Exercise 4
-- All functions in haskell are currified, so the composition is implemented as natural way
composeG :: (b -> c) -> (a -> b) -> a -> c
composeG f g = f . g

-- Exercise 5
nextChar :: Char -> Char
nextChar c = chr(((ord c) + 1) `mod` 256) -- ascii limits

