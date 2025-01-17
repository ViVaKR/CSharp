namespace NewFeature.Utilities;
public class SendData
{
    private readonly byte[] buffer;
    private int position;

    /// <summary>
    /// 지정된 크기의 SendData 객체를 초기화합니다. (생성자)
    /// </summary>
    /// <param name="bufferSize"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public SendData(int bufferSize)
    {
        if (bufferSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(bufferSize), "Buffer size must be positive");

        buffer = new byte[bufferSize];
    }

    /// <summary>
    /// 현재 버퍼 위치를 가져옵니다.
    /// </summary>
    public int Position => position;

    /// <summary>
    /// 버퍼의 총 크기를 가져옵니다.
    /// </summary>
    public int Capacity => buffer.Length;


    /// <summary>
    /// 버퍼 위치를 초기화합니다.
    /// </summary>
    public void Reset() => position = 0;

    /// <summary>
    /// 버퍼 세그먼트를 가져오고 위치를 업데이트합니다.
    /// </summary>
    /// <param name="size">요청할 버퍼 크기</param>
    /// <returns>버퍼 세그먼트</returns>
    public ArraySegment<byte> GetSegmentAndAdvance(int size)
    {
        var segment = GetSegment(size);
        position += size;
        return segment;
    }

    /// <summary>
    /// 지정된 크기의 버퍼 세그먼트를 가져옵니다.
    /// </summary>
    /// <param name="size">요청할 버퍼 크기</param>
    /// <returns>버퍼 세그먼트</returns>
    public ArraySegment<byte> GetSegment(int size)
    {
        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be positive");

        if (size > buffer.Length - position)
            throw new InvalidOperationException("Insufficient buffer space remaining");

        //--> 문의에 대한 답변: 버퍼의 현재 위치부터 지정된 크기만큼의 세그먼트를 반환
        return new ArraySegment<byte>(buffer, position, size);
    }
}

/*

--> 메모리 복사 없이 배열 일부분을 전달 가능함으로
-->  성능 향상을 기대할 수 있습니다.
- 장점
1. 메모리 효율성
2. 불필요한 배열 복사 방지
3. 네트워크 전송, 파일 입출력 등에서 성능 향상
4. 대용량 데이터 처리에 유리

new ArraySegment<byte>(
    buffer,    // 원본 배열 (Array),
    position,  // 시작 위치 (Offset)
    size       // 세그먼트 길이 (Count)
)


 */
