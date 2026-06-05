#pragma once
#include <string>

namespace rna_transcription {

    char to_rna(const char c);
    std::string to_rna(const std::string& sequence);

}  // namespace rna_transcription
