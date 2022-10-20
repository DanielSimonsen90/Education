male(daniel).
male(hans).
male(poul).
male(vagn).
male(mikkel).
male(michael).
male(frederik).
male(magnus).
male(carl).
male(ole).

female(mette).
female(helle).
female(jytte).
female(rita).
female(emilie).
female(lisbeth).

%parent(name, parentTo)
%first generation
parent(hans, daniel).
parent(hans, mikkel).
parent(hans, emilie).
parent(mette, daniel).
parent(mette, mikkel).
parent(mette, emilie).
parent(michael, frederik).
parent(michael, magnus).
parent(michael, carl).
parent(helle, frederik).
parent(helle, magnus).
parent(helle, carl).

%second generation
parent(poul, hans).
parent(rita, hans).
parent(vagn, mette).
parent(jytte, mette).
parent(ole, michael).
parent(lisbeth, michael).

married(mette, michael).
married(michael, mette).
married(jytte, vagn).
married(vagn, jytte).
married(rita, poul).
married(poul, rita).
married(lisbeth, ole).
married(ole, lisbeth).

grandParent(Name, GrandParentTo) :- 
    parent(Name, ParentTo), 
    parent(ParentTo, GrandParentTo).

mother(Name, MotherTo) :- 
    female(Name), 
    parent(Name, MotherTo).

stepMother(Name, StepMotherTo) :- 
    female(Name), 
    married(Name, Partner), 
    parent(Partner, StepMotherTo).

grandMother(Name, GrandMotherTo) :- 
    female(Name), 
    grandParent(Name, GrandMotherTo).

father(Name, FatherTo) :- 
    male(Name), 
    parent(Name, FatherTo).

stepFather(Name, StepFatherTo) :- 
    male(Name), 
    married(Name, Partner), 
    parent(Partner, StepFatherTo).

grandFather(Name, GrandFatherTo) :- 
    male(Name), 
    grandParent(Name, GrandFatherTo).

sibling(Name, SiblingTo) :- 
    parent(Parent, Name), 
    parent(Parent, SiblingTo), 
    not(Name = SiblingTo).

brothers(Name, Brother) :- 
    male(Name),
    male(Brother), 
    sibling(Name, Brother).

sisters(Name, Sister) :- 
    female(Name), 
    female(Sister), 
    sibling(Name, Sister).

stepSiblings(Name, StepTo) :- 
    parent(FirstParent, Name), 
    parent(SecondParent, StepTo), 
    married(FirstParent, SecondParent), 
    not(Name = StepTo).

stepBrothers(Name, StepBro) :- 
    male(Name), 
    male(StepBro), 
    stepSibling(Name, StepBro).

stepSisters(Name, StepSis) :-
    female(Name),
    female(StepSis),
    stepSibling(Name, StepSis).

divorced(Name, Partner) :- 
    parent(Name, Child), 
    parent(Partner, Child), 
    not(married(Name, Partner)), 
    not(Name = Partner).

% male(daniel)
% female(daniel)
% female(Females)
% male(Person), female(Person)
% grandFather(poul, daniel)
% grandParent(GrandParent, daniel)
