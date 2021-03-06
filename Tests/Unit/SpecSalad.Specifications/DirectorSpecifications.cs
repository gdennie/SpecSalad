﻿using System;
using Machine.Specifications;

namespace SpecSalad.Specifications
{
    [Subject("Director")]
    public class returns_the_class_instances : DirectorContext
    {
        It for_a_directive_for_something =
            () => _director.How_Do_I_Perform("Something").ShouldBeOfType<Something>();

        It for_a_directive_for_something_described_wtih_more_than_one_word =
            () => _director.How_Do_I_Perform("more than one word").ShouldBeOfType<MoreThanOneWord>();

        It exception_thrown_has_expected_message =
            () => Catch.Exception(() => _director.How_Do_I_Perform("Something that is not there")).Message.Contains("You need to define the role or task");	
    }

    public class DirectorContext
    {
        Establish context =
            () =>
                {
                    _director = new SaladDirector();
                };

        protected static SaladDirector _director;
    }
}