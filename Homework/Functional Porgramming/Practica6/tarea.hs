-- TPP Homework translated to Haskell
-- Author: Esteban Montes

module Practica5
(
 ownSearch,
 ownFilter,
 ownReduce,
) where
	-- Im a bit confused with what types I have to put for each one
    ownSearch c p = head $ownFilter c p
	
	ownFilter c p = [x | x <- c, p x]

    ownReduce f c [] = c
    ownReduce f c (x:xs) = ownReduce f (f c x) xs




    -- criteries
    criteryOne x = (x `mod` 2) == 0 -- test
    sumReduce x y =  x + y
    --- etc


-- Usage:

-- ownSearch [1..10] criteryOne || ownSearch [1..10] (\x -> (x `mod` 2) == 0)
-- ownFilter [1..10] criteryOne || ownFilter [1..10] (\x -> (x `mod` 2) == 0)
-- ownReduce [1..10] criteryOne

