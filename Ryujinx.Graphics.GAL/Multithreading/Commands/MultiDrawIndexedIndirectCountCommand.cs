﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct MultiDrawIndexedIndirectCountCommand : IGALCommand
    {
        public CommandType CommandType => CommandType.MultiDrawIndexedIndirectCount;
        private BufferRange _indirectBuffer;
        private BufferRange _parameterBuffer;
        private int _maxDrawCount;
        private int _stride;

        public void Set(BufferRange indirectBuffer, BufferRange parameterBuffer, int maxDrawCount, int stride)
        {
            _indirectBuffer = indirectBuffer;
            _parameterBuffer = parameterBuffer;
            _maxDrawCount = maxDrawCount;
            _stride = stride;
        }

        public static void Run(ref MultiDrawIndexedIndirectCountCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.MultiDrawIndexedIndirectCount(
                threaded.Buffers.MapBufferRange(command._indirectBuffer),
                threaded.Buffers.MapBufferRange(command._parameterBuffer),
                command._maxDrawCount,
                command._stride
                );
        }
    }
}
