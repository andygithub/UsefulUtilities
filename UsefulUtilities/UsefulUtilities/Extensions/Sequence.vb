Public Module Sequence

    <System.Runtime.CompilerServices.Extension>
    Public Function Replace(Of T)(source As IEnumerable(Of T), replacementValue As T, equalityComparer As Func(Of T, Boolean)) As IEnumerable(Of T)
        If equalityComparer Is Nothing Then Throw New ArgumentNullException("equalityComparer")

        Return source.[Select](Function(x) If(equalityComparer(x), replacementValue, x))
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function Replace(Of T)(source As IEnumerable(Of T), replacementValue As T, equalityComparer As IEquatable(Of T)) As IEnumerable(Of T)
        If equalityComparer Is Nothing Then Throw New ArgumentNullException("equalityComparer")

        Return source.[Select](Function(x) If(equalityComparer.Equals(x), replacementValue, x))
    End Function

End Module