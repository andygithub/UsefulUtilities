Imports UsefulUtilities

Public Class SequenceReplaceFixtures
    <Fact>
    Public Sub ReplaceNumberInSequence()
        Dim seq As New List(Of Integer) From {4, 2, 42, 1337, 7}
        Dim actual = seq.Replace(9, Function(i) i = 2).ToList
        Assert.Equal(New List(Of Integer) From {4, 9, 42, 1337, 7}, actual)
    End Sub

    <Fact>
    Public Sub ReplaceStringInSequence()
        Dim seq = New List(Of String) From {"foo", "bar", "baz", "qux", "corge", "grault"}
        Dim actual = seq.Replace("quux", "qux").ToList
        Assert.Equal(New List(Of String) From {"foo", "bar", "baz", "quux", "corge", "grault"}, actual)
    End Sub

    <Fact>
    Public Sub ReplaceWithNullFuncThrows()
        Dim seq = New List(Of Object)() From {New Object(), New Object()}
        Dim dummyValue = New Object()
        Assert.Throws(Of ArgumentNullException)(Function() seq.Replace(dummyValue, DirectCast(Nothing, Func(Of Object, Boolean))).ToList())
    End Sub

    <Fact> _
    Public Sub ReplaceWithNullEquatableThrows()
        Dim seq = New List(Of Object)() From {New Object(), New Object()}
        Dim dummyValue = New Object()
        Assert.Throws(Of ArgumentNullException)(Function() seq.Replace(dummyValue, DirectCast(Nothing, IEquatable(Of Object))).ToList())
    End Sub

End Class